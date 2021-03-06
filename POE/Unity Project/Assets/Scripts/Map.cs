﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


    class Map
    {
        //**************************************************************************************************************** Variables *************************************************************************************************************************************
        System.Random random = new System.Random();
        char[,] arrMap = new char[20, 20];
        Unit[] arrUnit = new Unit[10];
        Building[] arrBuilding = new Building[4];
        char Symbol;
        int xpos, ypos;
        string Faction;

    //**************************************************************************************************************** G&S's *************************************************************************************************************************************

   public char[,] ArrMap
    {
        get
        {
            return arrMap;
        }
        set
        {
            arrMap = value;
        }
    }

    internal Unit[] ArrUnit
    {
        get
        {
            return arrUnit;
        }
        set
        {
            arrUnit = value;
        }
    }

    internal Building[] ArrBuilding
    {
        get
        {
            return arrBuilding;
        }
        set
        {
            arrBuilding = value;
        }
    }
    //**************************************************************************************************************** Methods *************************************************************************************************************************************

    public void PopulateBattlefield()
    {
        arrBuilding[0] = new FactoryBuilding("Hero", 19, 19);
        arrBuilding[1] = new FactoryBuilding("Enemy", 0, 19);
        arrBuilding[2] = new ResourceBuilding("Hero", 0, 0);
        arrBuilding[3] = new ResourceBuilding("Enemy", 19, 0);

        for (int j = 0; j < 20; j++)
        {
            for (int i = 0; i < 20; i++)
            {
                arrMap[j, i] = ',';
            }
        }

        
        arrMap[19, 19] = arrBuilding[0].Buildingsymbol;
        arrMap[0, 19] = arrBuilding[1].Buildingsymbol;
        arrMap[0, 0] = arrBuilding[2].Buildingsymbol;
        arrMap[19, 0] = arrBuilding[3].Buildingsymbol;

        for (int i = 0; i < ArrUnit.Length; i++)
        {
            int number = random.Next(1, 10);
            xpos = random.Next(1, 20);
            ypos = random.Next(1, 20);

            if (arrMap[xpos, ypos] != '#' && arrMap[xpos, ypos] != '@')
            {
                if (number % 2 == 0 && arrMap[xpos, ypos] == ',')
                {
                    int number2 = random.Next(1, 10);

                    if (number2 % 2 == 0)
                    {
                        Faction = "Hero";
                        Symbol = '$';
                    }

                    if (number2 % 2 != 0)
                    {
                        Faction = "Enemy";
                        Symbol = '%';
                    }

                    ArrUnit[i] = new MeleeUnit(xpos, ypos, Faction, Symbol);
                    arrMap[xpos, ypos] = Symbol;
                }

                else if (number % 2 != 0 && arrMap[xpos, ypos] == ',')
                {
                    int number3 = random.Next(1, 10);

                    if (number3 % 2 == 0)
                    {
                        Faction = "Hero";
                        Symbol = '^';
                    }

                    if (number3 % 2 != 0)
                    {
                        Faction = "Enemy";
                        Symbol = '&';
                    }

                    

                    ArrUnit[i] = new RangedUnit(xpos, ypos, Faction, Symbol);
                    arrMap[xpos, ypos] = Symbol;
                }
                else
                {
                    i--;
                }

            }
            else
            {
                i--;
            }
        }

    }

       

    }

