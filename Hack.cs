using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Vectrosity;
using System.Reflection;

namespace sslAimAssist
{
    class Hack : MonoBehaviour
    {
        private const string NOT_FOUND = "未开始游戏...";
        private const string INIT_MESSAGE = "载入成功...";

        private string OverlayString = INIT_MESSAGE;

        private int _lastPower = 0;
        private int _lastAngle = 0;
        private float lastTime = Time.time;
        private float windsalt = 100f;
        private float r = 10f;
        private float booster = 0.01f;
        private int lockport = 0;
        //private float g = 9.8f;
        //private int increment = 1;
        //private int count = 0;
        //private double[] powerSalt={5.5, 5.5, 5.5, 5.5, 5.5, 5.5, 5.5, 5.5, 5.5, 5.5, 5.5, 5.5, 5.5, 5.5, 5.5, 5.5, 5.5, 5.5, 5.5, 5.5, 5.5, 5.5, 5.5, 5.5, 5.5, 5.5, 5.5, 5.5, 5.5, 5.5, 6.0, 6.0, 6.0, 6.0, 6.0, 6.25, 6.25, 6.25, 6.25, 6.25, 6.5, 6.5, 6.5, 6.5, 6.5, 7.0, 7.0, 7.0, 7.0, 7.0, 7.75, 7.75, 7.75, 7.75, 7.75, 8.25, 8.25, 8.25, 8.25, 8.25, 8.75, 8.75, 8.75, 8.75, 8.75, 9.5, 9.5, 9.5, 9.5, 9.5, 9.75, 9.75, 9.75, 9.75, 9.75, 10.5, 10.5, 10.5, 10.5, 10.5, 11.0, 11.0, 11.0, 11.0, 11.0, 11.5, 11.5, 11.5, 11.5, 11.5, 12.25, 12.25, 12.25, 12.25, 12.25, 12.75, 12.75, 12.75, 13.25, 13.25, 13.25 };
        private List<TracerLine> linelist = new List<TracerLine>();
        //private int tick = 1;
        private int checkbumperlimit = 0;
        private List<Prop_Bumper> bumperlist = new List<Prop_Bumper>();
        private List<Prop_CBumper> cbumperlist = new List<Prop_CBumper>();
        private List<Prop_Portal> portallist = new List<Prop_Portal>();

        private List<Collider2D> colliderlist = new List<Collider2D>();

        private float cbrplus = 0f;
        //private static float RAD2DEG = 180f / 3.14159274f;
        //private static float DEG2RAD = 3.14159274f / 180f;
        private static double velBase = 0.100799993944168;
        private static double velYBase = -0.0783999973297119;
        private Vector2 leftp1, leftp2, rightp1, rightp2;
        private int height = 99;

        private bool bumperlock = false;
        void Start()
        {

        }

        void Update()
        {
            /*
            if (Input.GetKeyDown(KeyCode.Keypad2))
            {
                //increment += 1;
                //dtime += 0.001f;
                
            }
            if (Input.GetKeyDown(KeyCode.Keypad3))
            {
                
                
                tick -= 1;
                if (tick <1)
                {
                    tick = 1;
                }
                //increment -= 1;
                //if (increment < 1)
                //{
                //    increment = 1;                    
                //}
            }
            
            if (Input.GetKeyDown(KeyCode.Keypad5))
            {
                //this.windsalt -= 0.0001;
                //this.booster -= 0.0001;
                //this.cbrplus -= 0.01f;
                height -= 1;
            }
            if (Input.GetKeyDown(KeyCode.Keypad6))
            {
                height += 1;
                //this.windsalt += 0.0001;
                //this.booster += 0.0001;
                //this.cbrplus += 0.01f;
            }
            
            if (Input.GetKeyDown(KeyCode.Keypad8))
            {
                this.booster -= 0.01f;
                if (booster < 0.01f)
                {
                    booster = 0.01f;
                }
                //this.windsalt -= 0.0001;
                //this.r -= 0.1;
            }*/
            /*
            if (Input.GetKeyDown(KeyCode.Keypad9))
            {
                foreach(TracerLine t in linelist)
                {
                    VectorLine.Destroy(ref t.line);
                }
                linelist.Clear();
            }*/


            DateTime now = DateTime.Now;
            if (now.Year == 2016 && now.Month <= 10)
            {
                CreaterLock = true;
            }
            else
            {
                CreaterLock = false;
            }

            if (Game.round.me.mc != null && CreaterLock)
            {

                leftp1 = new Vector2(0f, Map.mapY(0f));
                leftp2 = new Vector2(0f, (float)(Map.mapY(0f) + height));
                rightp1 = new Vector2(1000f, Map.mapY(1000f));
                rightp2 = new Vector2(1000f, (float)(Map.mapY(1000f) + height));

                if (Game.round.me.lvl > 84)
                {
                    bumperlock = true;
                }
                else
                {
                    bumperlock = false;
                }
                
                //OverlayString = String.Format("wep:{0}|wepind|{1}", WeaponSelector.instance.selFam.key, WeaponSelector.instance.selInd);
                //OverlayString = "力度::" + Aimer.instance.power + " 角度::" + Aimer.instance.angle  + "  "/* + powerSalt[Aimer.instance.power] + " 风:: "+ WindInd.instance.wind * 100*/;
                //OverlayString = "bs: " + this.booster + " r:"+ this.r;
                //OverlayString += Environment.NewLine + "侧面挡板高"+height;
                //OverlayString += Environment.NewLine + string.Format("ME:: X={0:0.0###}   Y={1}", Game.round.me.x, Game.round.me.y);
                /*OverlayString += Environment.NewLine + String.Format("X:{0}|Y:{1}|Xvel:{2}|Yvel:{3}|Xacc:{4}|Yacc:{5}|", Game.round.me.x + r * Mathf.Sin(Aimer.instance.angle * Mathf.Deg2Rad), Game.round.me.y + r * Mathf.Cos(Aimer.instance.angle * Mathf.Deg2Rad), Mathf.Sin(Aimer.instance.angle * Mathf.Deg2Rad) * velBase * Aimer.instance.power, Mathf.Cos(Aimer.instance.angle * Mathf.Deg2Rad) * velBase * Aimer.instance.power, 0, 0.0);
                foreach (Sim_Proj pj in Simulator.simProjs)
                {
                    OverlayString += Environment.NewLine + String.Format("startTick:{0}|endTick:{1}|startProjTick:{2}|", pj.startTick, pj.endTick, pj.startProjTick);
                    OverlayString += Environment.NewLine + String.Format("X:{0}|Y:{1}|Xvel:{2}|Yvel:{3}|Xacc:{4}|Yacc:{5}|Angle:{6}", pj.X, pj.Y, pj.Xvel, pj.Yvel, pj.Xacc, pj.Yacc, 90.0 - 180.0 * Mathf.Atan2((float)pj.Yvel, (float)pj.Xvel) / 3.14159274);
                    OverlayString += Environment.NewLine + String.Format("mnum:{0}|mparam:{1}|rad:{2}|rot:{3}|tid:{4}|id:{5}|gScl:{6}", pj.motionNum, pj.motionParam, pj.rad, pj.rot, pj.tid, pj.id,pj.glowScl);
                }*/
                OverlayString = "";


                bumperlist.Clear();
                cbumperlist.Clear();
                portallist.Clear();
                foreach (GameProp prop in Game.round.currentProps)
                {
                    if (prop is Prop_Bumper)
                    {
                        Prop_Bumper pb = (Prop_Bumper)prop;
                        bumperlist.Add(pb);
                    }
                    else if (prop is Prop_CBumper)
                    {
                        Prop_CBumper pb = (Prop_CBumper)prop;
                        cbumperlist.Add(pb);
                    }
                    else if (prop is Prop_Portal)
                    {

                        Prop_Portal pb = (Prop_Portal)prop;
                        portallist.Add(pb);
                    }

                }
                if ((Time.time > lastTime + 0.75) && (Aimer.instance.power != _lastPower || Aimer.instance.angle != _lastAngle))
                {
                    lastTime = Time.time;
                    _lastAngle = Aimer.instance.angle;
                    _lastPower = Aimer.instance.power;
                    checkbumperlimit = 0;
                    Proj_Motion();
                }
            }
            else
            {
                OverlayString = NOT_FOUND;
            }
        }

        private void Proj_Motion()
        {
            //Clear linelist
            foreach (TracerLine tr in linelist)
            {
                VectorLine.Destroy(ref tr.line);
            }
            linelist.Clear();
            // Base calculate data init

            int dAngle = Aimer.instance.angle;
            int power = Aimer.instance.power;
            float Xpos = Mathf.RoundToInt(Game.round.me.x) + this.r * Mathf.Sin(dAngle * Mathf.Deg2Rad);
            float Ypos = Game.round.me.y + this.r * Mathf.Cos(dAngle * Mathf.Deg2Rad);
            float Xacc = 0;
            if (Game.options.wind > 0)
            {
                Xacc = (float)WindInd.instance.GetType().GetField("wind", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(WindInd.instance) / windsalt;
            }
            Vector2 position = new Vector2(Xpos, Ypos);
            Vector2 speed = new Vector2((float)(power * velBase * Mathf.Sin(dAngle * Mathf.Deg2Rad)), (float)(power * velBase * Mathf.Cos(dAngle * Mathf.Deg2Rad)));
            Vector2 acc = new Vector2((float)Xacc, (float)velYBase);
            int limit = 0;

            //Special Gravity And Horizon Power

            switch (WeaponSelector.instance.selFam.key)
            {
                case "gull":
                    speed = new Vector2((float)(power * 0.0705599969291687 * Mathf.Sin(dAngle * Mathf.Deg2Rad)), (float)(power * 0.0705599969291687 * Mathf.Cos(dAngle * Mathf.Deg2Rad)));
                    acc.y = (float)(velYBase / 2.0);
                    break;
                case "bfg":
                    speed = new Vector2((float)(power * 0.0705599969291687 * Mathf.Sin(dAngle * Mathf.Deg2Rad)), (float)(power * 0.0705599969291687 * Mathf.Cos(dAngle * Mathf.Deg2Rad)));
                    acc.y = (float)(velYBase / 2.0);
                    break;
                case "chopper":
                    speed = new Vector2((float)(power * 0.0705599969291687 * Mathf.Sin(dAngle * Mathf.Deg2Rad)), (float)(power * 0.0705599969291687 * Mathf.Cos(dAngle * Mathf.Deg2Rad)));
                    acc.y = (float)(velYBase / 2.0);
                    break;
                case "3d":
                    speed = new Vector2((float)(power * velBase / 2.0 * Mathf.Sin(dAngle * Mathf.Deg2Rad)), (float)(power * velBase / 2.0 * Mathf.Cos(dAngle * Mathf.Deg2Rad)));
                    acc.y = 0f;
                    limit = 100;
                    break;
                case "boomerang":
                    acc.x -= (float)0.000705599957275391 * power * Mathf.Sin(dAngle * Mathf.Deg2Rad);
                    break;
            }
            // start create line
            if (WeaponSelector.instance.selFam.key == "hover")
            {
                bool topcheck = false;
                int limithover = 0;
                if (WeaponSelector.instance.selInd == 0)
                {
                    limithover = 40;
                }
                else
                {
                    limithover = 50;
                }
                if (speed.y > 0)
                {
                    topcheck = true;
                }
                Vector2 hoveracc = new Vector2(acc.x, 0);
                CalculateLineTOPCHECK(ref position, ref speed, acc);
                while (topcheck)
                {
                    CalculateLineLIMIT(ref position, ref speed, hoveracc, limithover);
                    CalculateLineLIMIT(ref position, ref speed, acc, 1);
                    if (speed.y > 0)
                    {
                        topcheck = true;
                    }
                    else
                    {
                        topcheck = false;
                    }
                    CalculateLineTOPCHECK(ref position, ref speed, acc);
                    if (position.x <= 1000 && position.x >= 0 && position.y > Map.mapY(position.x) && speed.y - acc.y > 0)
                    {
                        topcheck = true;
                    }
                }
            }
            else if (WeaponSelector.instance.selFam.key == "3d")
            {
                CalculateLineLIMIT(ref position, ref speed, acc, limit);
            }
            else if (WeaponSelector.instance.selFam.key == "batterram")
            {
                Vector2 batterramacc = new Vector2(acc.x, -0.39199998664856f);
                CalculateLineTOPCHECK(ref position, ref speed, acc);
                CalculateLineNORMAL(position, speed, batterramacc);
            }
            else if (WeaponSelector.instance.selFam.key == "dropper" && WeaponSelector.instance.selInd == 0)// && speed.y <= 0 && speed.y - acc.y >= 0
            {
                Vector2 payload = new Vector2(0f, -1.39999997615814f);
                bool topcheck = false;
                if (speed.y > 0)
                {
                    topcheck = true;
                }
                CalculateLineTOPCHECK(ref position, ref speed, acc);
                while (topcheck)
                {

                    CalculateLineNORMAL(position, payload, acc);
                    CalculateLineLIMIT(ref position, ref speed, acc, 1);
                    if (speed.y - acc.y > 0)
                    {
                        topcheck = true;
                    }
                    else
                    {
                        topcheck = false;
                    }
                    CalculateLineTOPCHECK(ref position, ref speed, acc);
                    if (position.x <= 1000 && position.x >= 0 && position.y > Map.mapY(position.x) && speed.y - acc.y > 0)
                    {
                        topcheck = true;
                    }
                }
            }
            else if (WeaponSelector.instance.selFam.key == "dropper" && WeaponSelector.instance.selInd == 1)//&& (t - 41) % 15 == 0 && t >= 41
            {
                Vector2 payload = new Vector2(0f, -1.39999997615814f);
                CalculateLineCHILD(position, speed, acc, 41, 15, payload);
            }
            else if (WeaponSelector.instance.selFam.key == "gull")//&& (t - 51) % 25 == 0 && t >= 51
            {
                float vx = speed.x / 3.5714286322496298512551346942903f;
                Vector2 gull = new Vector2(vx, -2.79999995231628f);
                CalculateLineCHILD(position, speed, acc, 51, 25, gull);
            }
            else if (WeaponSelector.instance.selFam.key == "fleet")
            {
                float basefleet = 0.4583603f;
                Vector2 fleet = speed;
                CalculateLineNORMAL(position, fleet, acc);
                for (int i = 1; i < 6; i++)
                {
                    Vector2 fleettemp = new Vector2((float)(power * velBase * Mathf.Sin((dAngle + basefleet * i) * Mathf.Deg2Rad)), (float)(power * velBase * Mathf.Cos((dAngle + basefleet * i) * Mathf.Deg2Rad)));
                    CalculateLineNORMAL(position, fleettemp, acc);
                    Vector2 fleettempmirro = new Vector2((float)(power * velBase * Mathf.Sin((dAngle - basefleet * i) * Mathf.Deg2Rad)), (float)(power * velBase * Mathf.Cos((dAngle - basefleet * i) * Mathf.Deg2Rad)));
                    CalculateLineNORMAL(position, fleettempmirro, acc);
                }
            }
            else if (WeaponSelector.instance.selFam.key == "count")
            {
                float basefleet = 2.8647861f;
                Vector2 count = speed;
                CalculateLineNORMAL(position, count, acc);
                for (int i = 1; i < WeaponSelector.instance.selInd + 3; i++)
                {
                    Vector2 fleettemp = new Vector2((float)(power * velBase * Mathf.Sin((dAngle + basefleet * i) * Mathf.Deg2Rad)), (float)(power * velBase * Mathf.Cos((dAngle + basefleet * i) * Mathf.Deg2Rad)));
                    CalculateLineNORMAL(position, fleettemp, acc);
                    Vector2 fleettempmirro = new Vector2((float)(power * velBase * Mathf.Sin((dAngle - basefleet * i) * Mathf.Deg2Rad)), (float)(power * velBase * Mathf.Cos((dAngle - basefleet * i) * Mathf.Deg2Rad)));
                    CalculateLineNORMAL(position, fleettempmirro, acc);
                }
            }
            else if (WeaponSelector.instance.selFam.key == "pinata" && WeaponSelector.instance.selInd == 1)
            {
                float basefleet = 11.459158f;
                Vector2 count = speed;
                CalculateLineNORMAL(position, count, acc);
                for (int i = 1; i < 2; i++)
                {
                    Vector2 fleettemp = new Vector2((float)(power * velBase * Mathf.Sin((dAngle + basefleet * i) * Mathf.Deg2Rad)), (float)(power * velBase * Mathf.Cos((dAngle + basefleet * i) * Mathf.Deg2Rad)));
                    CalculateLineNORMAL(position, fleettemp, acc);
                    Vector2 fleettempmirro = new Vector2((float)(power * velBase * Mathf.Sin((dAngle - basefleet * i) * Mathf.Deg2Rad)), (float)(power * velBase * Mathf.Cos((dAngle - basefleet * i) * Mathf.Deg2Rad)));
                    CalculateLineNORMAL(position, fleettempmirro, acc);
                }
            }
            else if (WeaponSelector.instance.selFam.key == "stickybomb" && WeaponSelector.instance.selInd == 1)
            {
                float basefleet = 5.7295791f;
                Vector2 count = speed;
                CalculateLineNORMAL(position, count, acc);
                for (int i = 1; i < 2; i++)
                {
                    Vector2 fleettemp = new Vector2((float)(power * velBase * Mathf.Sin((dAngle + basefleet * i) * Mathf.Deg2Rad)), (float)(power * velBase * Mathf.Cos((dAngle + basefleet * i) * Mathf.Deg2Rad)));
                    CalculateLineNORMAL(position, fleettemp, acc);
                    Vector2 fleettempmirro = new Vector2((float)(power * velBase * Mathf.Sin((dAngle - basefleet * i) * Mathf.Deg2Rad)), (float)(power * velBase * Mathf.Cos((dAngle - basefleet * i) * Mathf.Deg2Rad)));
                    CalculateLineNORMAL(position, fleettempmirro, acc);
                }
            }
            else if (WeaponSelector.instance.selFam.key == "minion")
            {
                float[] basepower = {
                        0.115919994955063f,
                        0.11289599508667f,
                        0.0856799962711335f,
                        0.0887039961395264f,
                        0.091729960079193f,
                        0.109871995218277f
                    };

                for (int i = 0; i < (WeaponSelector.instance.selInd + 2) * 2; i++)
                {
                    Vector2 minion = new Vector2((float)(power * basepower[i] * Mathf.Sin((dAngle) * Mathf.Deg2Rad)), (float)(power * basepower[i] * Mathf.Cos((dAngle) * Mathf.Deg2Rad)));
                    CalculateLineNORMAL(position, minion, acc);
                }
            }
            else if (WeaponSelector.instance.selFam.key == "multiball" && WeaponSelector.instance.selInd < 2)
            {
                float basefleet = 5.7295791f;
                Vector2 count = speed;
                CalculateLineNORMAL(position, count, acc);
                for (int i = 1; i < WeaponSelector.instance.selInd + 2; i++)
                {
                    Vector2 fleettemp = new Vector2((float)(power * velBase * Mathf.Sin((dAngle + basefleet * i) * Mathf.Deg2Rad)), (float)(power * velBase * Mathf.Cos((dAngle + basefleet * i) * Mathf.Deg2Rad)));
                    CalculateLineNORMAL(position, fleettemp, acc);
                    Vector2 fleettempmirro = new Vector2((float)(power * velBase * Mathf.Sin((dAngle - basefleet * i) * Mathf.Deg2Rad)), (float)(power * velBase * Mathf.Cos((dAngle - basefleet * i) * Mathf.Deg2Rad)));
                    CalculateLineNORMAL(position, fleettempmirro, acc);
                }
            }
            else if (WeaponSelector.instance.selFam.key == "multiball" && WeaponSelector.instance.selInd == 2)
            {
                float basefleet = 2.8647929f;
                Vector2 count = speed;
                CalculateLineNORMAL(position, count, acc);
                for (int i = 1; i < 6; i++)
                {
                    Vector2 fleettemp = new Vector2((float)(power * velBase * Mathf.Sin((dAngle + basefleet * i) * Mathf.Deg2Rad)), (float)(power * velBase * Mathf.Cos((dAngle + basefleet * i) * Mathf.Deg2Rad)));
                    CalculateLineNORMAL(position, fleettemp, acc);
                    Vector2 fleettempmirro = new Vector2((float)(power * velBase * Mathf.Sin((dAngle - basefleet * i) * Mathf.Deg2Rad)), (float)(power * velBase * Mathf.Cos((dAngle - basefleet * i) * Mathf.Deg2Rad)));
                    CalculateLineNORMAL(position, fleettempmirro, acc);
                }
            }
            else if (WeaponSelector.instance.selFam.key == "multiball" && WeaponSelector.instance.selInd == 3)
            {
                float basefleet = 1.7188785f;
                Vector2 count = speed;
                CalculateLineNORMAL(position, count, acc);
                for (int i = 1; i < 13; i++)
                {
                    Vector2 fleettemp = new Vector2((float)(power * velBase * Mathf.Sin((dAngle + basefleet * i) * Mathf.Deg2Rad)), (float)(power * velBase * Mathf.Cos((dAngle + basefleet * i) * Mathf.Deg2Rad)));
                    CalculateLineNORMAL(position, fleettemp, acc);
                    Vector2 fleettempmirro = new Vector2((float)(power * velBase * Mathf.Sin((dAngle - basefleet * i) * Mathf.Deg2Rad)), (float)(power * velBase * Mathf.Cos((dAngle - basefleet * i) * Mathf.Deg2Rad)));
                    CalculateLineNORMAL(position, fleettempmirro, acc);
                }
            }
            else if (WeaponSelector.instance.selFam.key == "tunnel" && WeaponSelector.instance.selInd == 1)
            {
                float basefleet = 2.8647929f;
                Vector2 count = speed;
                Vector2 pos = position;
                CalculateLineUNDERCHECK(ref pos, ref count, acc);
                for (int i = 1; i < 5; i++)
                {
                    pos = position;
                    Vector2 fleettemp = new Vector2((float)(power * velBase * Mathf.Sin((dAngle + basefleet * i) * Mathf.Deg2Rad)), (float)(power * velBase * Mathf.Cos((dAngle + basefleet * i) * Mathf.Deg2Rad)));
                    CalculateLineUNDERCHECK(ref pos, ref fleettemp, acc);
                    pos = position;
                    Vector2 fleettempmirro = new Vector2((float)(power * velBase * Mathf.Sin((dAngle - basefleet * i) * Mathf.Deg2Rad)), (float)(power * velBase * Mathf.Cos((dAngle - basefleet * i) * Mathf.Deg2Rad)));
                    CalculateLineUNDERCHECK(ref pos, ref fleettempmirro, acc);
                }
            }
            else if (WeaponSelector.instance.selFam.key == "tunnel" && (WeaponSelector.instance.selInd == 0 || WeaponSelector.instance.selInd == 3))
            {
                CalculateLineUNDERCHECK(ref position, ref speed, acc);
            }
            else if (WeaponSelector.instance.selFam.key == "bounsplode" && WeaponSelector.instance.selInd == 1)
            {
                float basefleet = 5.7295791f;
                for (int i = 1; i < 2; i++)
                {
                    Vector2 fleettemp = new Vector2((float)(power * velBase * Mathf.Sin((dAngle + basefleet * i) * Mathf.Deg2Rad)), (float)(power * velBase * Mathf.Cos((dAngle + basefleet * i) * Mathf.Deg2Rad)));
                    CalculateLineNORMAL(position, fleettemp, acc);
                    Vector2 fleettempmirro = new Vector2((float)(power * velBase * Mathf.Sin((dAngle - basefleet * i) * Mathf.Deg2Rad)), (float)(power * velBase * Mathf.Cos((dAngle - basefleet * i) * Mathf.Deg2Rad)));
                    CalculateLineNORMAL(position, fleettempmirro, acc);
                }
            }
            else if (WeaponSelector.instance.selFam.key == "bounsplode" && WeaponSelector.instance.selInd == 2)
            {
                float basefleet = 8.5943721f;
                Vector2 count = speed;
                CalculateLineNORMAL(position, count, acc);
                for (int i = 1; i < 2; i++)
                {
                    Vector2 fleettemp = new Vector2((float)(power * velBase * Mathf.Sin((dAngle + basefleet * i) * Mathf.Deg2Rad)), (float)(power * velBase * Mathf.Cos((dAngle + basefleet * i) * Mathf.Deg2Rad)));
                    CalculateLineNORMAL(position, fleettemp, acc);
                    Vector2 fleettempmirro = new Vector2((float)(power * velBase * Mathf.Sin((dAngle - basefleet * i) * Mathf.Deg2Rad)), (float)(power * velBase * Mathf.Cos((dAngle - basefleet * i) * Mathf.Deg2Rad)));
                    CalculateLineNORMAL(position, fleettempmirro, acc);
                }
            }
            else if (WeaponSelector.instance.selFam.key == "rainbow")
            {
                int[] weidth = { 12, 20 };
                float[] baseposy = { position.y - 30f, position.y - 50f };
                for (int i = 0; i < 6; i++)
                {
                    Vector2 rainbowpos = new Vector2(position.x, baseposy[WeaponSelector.instance.selInd] + weidth[WeaponSelector.instance.selInd] * i);
                    CalculateLineNORMALT(rainbowpos, speed, acc);
                }
            }
            else if (WeaponSelector.instance.selFam.key == "quicksand")
            {
                TracerLine mask = CalculateLineNORMALTTS(position, speed, acc);
                Vector2 lastpos = new Vector2(Map.worldToMapX(mask.line.points3.Last().x), Map.worldToMapY(mask.line.points3.Last().y));
                mask.line.points3.Add(new Vector3(Map.toWorldX(lastpos.x), Map.toWorldY(Map.mapY(lastpos.x))));
            }
            else if (WeaponSelector.instance.selFam.key == "gravits")
            {
                double[][] g = { new double[4]{
                            -0.101919996528626,
                            -0.0862399970626831,
                            -0.0705599975967408,
                            -0.0548799981307984
                        }, new double[6]{
                            -0.107799996328354,
                            -0.0960399967288971,
                            -0.0842799971294403,
                            -0.0725199975299835,
                            -0.0607599979305267,
                            -0.0489999999833107,
                        }  };
                for (int i = 0; i < g[WeaponSelector.instance.selInd].Length; i++)
                {

                    Vector2 gravits = new Vector2(acc.x, (float)g[WeaponSelector.instance.selInd][i]);
                    CalculateLineNORMAL(position, speed, gravits);
                }
            }
            else if (WeaponSelector.instance.selFam.key == "stream" && WeaponSelector.instance.selInd < 3)
            {
                float[] tempangle = {
                        -14.2880587f,
                        -14.1715084f,
                        -13.0247265f,
                        -13.4358560f,
                        -12.0531799f,
                        -11.4374793f,
                        -9.4106344f,
                        -8.5724814f,
                        -6.8672632f,
                        -5.9031616f,
                        -3.0813647f,
                        -2.0213944f,
                        0f,
                        1.0764650f,
                        4.0023332f,
                        5.0246012f,
                        10.8403978f,
                        10.1061252f,
                        13.7355783f,
                        14.0020854f
                    };
                float[] buff = {
                        8f,
                        2f,
                        1f
                    };
                foreach (float angle in tempangle)
                {
                    Vector2 fleettemp = new Vector2((float)(power * velBase * Mathf.Sin((dAngle + angle / buff[WeaponSelector.instance.selInd]) * Mathf.Deg2Rad)), (float)(power * velBase * Mathf.Cos((dAngle + angle / buff[WeaponSelector.instance.selInd]) * Mathf.Deg2Rad)));
                    CalculateLineNORMAL(position, fleettemp, acc);
                }
            }
            else if (WeaponSelector.instance.selFam.key == "fire" && false)
            {
                float[] tempangle = {
                        -14.2880587f,
                        -14.1715084f,
                        -13.0247265f,
                        -13.4358560f,
                        -12.0531799f,
                        -11.4374793f,
                        -9.4106344f,
                        -8.5724814f,
                        -6.8672632f,
                        -5.9031616f,
                        -3.0813647f,
                        -2.0213944f,
                        0f,
                        1.0764650f,
                        4.0023332f,
                        5.0246012f,
                        10.8403978f,
                        10.1061252f,
                        13.7355783f,
                        14.0020854f
                    };
                float[] buff = {
                        8f,
                        2f,
                        1f
                    };
                foreach (float angle in tempangle)
                {
                    Vector2 fleettemp = new Vector2((float)(power * velBase * Mathf.Sin((dAngle + angle / buff[WeaponSelector.instance.selInd]) * Mathf.Deg2Rad)), (float)(power * velBase * Mathf.Cos((dAngle + angle / buff[WeaponSelector.instance.selInd]) * Mathf.Deg2Rad)));
                    CalculateLineNORMAL(position, fleettemp, acc);
                }
            }
            else if (WeaponSelector.instance.selFam.key == "snipe" && WeaponSelector.instance.selInd == 1)
            {
                CalculateLineUNDERCHECK(ref position, ref speed, acc);
            }
            else if (WeaponSelector.instance.selFam.key == "ringer")
            {
                if (WeaponSelector.instance.selInd == 0)
                {
                    
                    CalculateLineFLOORCHECK(ref position, ref speed, acc);
                    position.y = Map.mapY(position.x);
                    DrawCircle(position, 50f, 30f);
                }
                else if(WeaponSelector.instance.selInd == 2)
                {
                    
                    CalculateLineFLOORCHECK(ref position, ref speed, acc);
                    position.y = Map.mapY(position.x);
                    DrawCircle(position, 75f, 30f);
                }
                else
                {
                    
                    CalculateLineFLOORCHECK(ref position, ref speed, acc);
                    position.y = Map.mapY(position.x);
                    DrawCircle(position, 100f, 50f);
                }
            }
            else if (WeaponSelector.instance.selFam.key == "v")
            {
                TracerLine t =  CalculateLineNORMAL(position,speed, acc);
                float[] vel =
                    {
                        0.0559999990463257f,1.25999997854233f,
                        -0.111999998092651f,2.37999995946884f,
                        0.167999997138977f,3.49999994039536f,
                        -0.223999996185303f,4.61999992132187f,
                        0.279999995231628f,5.73999990224838f,
                        -0.335999994277954f,6.8599998831749f,
                        0.39199999332428f,7.97999986410141f,
                        -0.447999992370606f,9.09999984502792f,
                        0.503999991416931f,10.2199998259544f,
                        -0.559999990463257f,11.339999806881f
                    };
                position.y = Map.mapY(position.x);
                Vector2 lp = new Vector2(Map.worldToMapX(t.line.points3.ElementAt(t.line.points3.Count - 2).x), Map.worldToMapY(t.line.points3.ElementAt(t.line.points3.Count-2).y));
                Vector2 p = new Vector2(Map.worldToMapX(t.line.points3.Last().x), Map.worldToMapY(t.line.points3.Last().y));
                position = CheckFloor(lp, p);
                for (int i = 0; i < (3 + WeaponSelector.instance.selInd * 2) * 2; i++)
                {
                    Vector2 vspeed = new Vector2(vel[i * 2], vel[i * 2 + 1]);
                    CalculateLineNORMAL(position, vspeed, acc);
                }
            }
            else if (WeaponSelector.instance.selFam.key == "geo")
            {
                int[] part = { 4, 6, 8 };
                List<Vector2> spdlist = new List<Vector2>();
                TracerLine rewirte = CalculateLineSPEED(position, speed, acc, ref spdlist);
                Vector2 lastpos = new Vector2(Map.worldToMapX(rewirte.line.points3.Last().x), Map.worldToMapY(rewirte.line.points3.Last().y));
                if (rewirte.line.points3.Count>15 && lastpos.y <= Map.mapY(lastpos.x))
                {
                    for (int i = 0; i < 15; i++)
                    {
                        rewirte.line.points3.RemoveAt(rewirte.line.points3.Count - 1);
                        spdlist.RemoveAt(spdlist.Count - 1);
                    }
                }
                float rotbase = 0;
                foreach (Vector2 spd in spdlist)
                {
                    rotbase += (float)( -1f * spd.x);
                }
                //debugmessage = Environment.NewLine + rewirte.line.points3.Count + "|||||";
                Vector2 basespeed = new Vector2(0f, 2.8f);
                for (int i = 0; i < part[WeaponSelector.instance.selInd]; i++)
                {
                    Vector2 mappos = new Vector2(Map.worldToMapX(rewirte.line.points3.Last().x), Map.worldToMapY(rewirte.line.points3.Last().y));
                    CalculateLineNORMAL(mappos, basespeed.Rotate((360f / part[WeaponSelector.instance.selInd]) * (float)i + rotbase), acc);
                }
            }
            else if (WeaponSelector.instance.selFam.key == "split" && WeaponSelector.instance.selInd <3)
            {
                List<Vector2> spdlist = new List<Vector2>();
                TracerLine rewirte = CalculateLineSPEED(position, speed, acc, ref spdlist);
                Vector2 lastpos = new Vector2(Map.worldToMapX(rewirte.line.points3.Last().x), Map.worldToMapY(rewirte.line.points3.Last().y));
                if (rewirte.line.points3.Count > 35 && lastpos.y <= Map.mapY(lastpos.x))
                {
                    for (int i = 0; i < 35; i++)
                    {
                        rewirte.line.points3.RemoveAt(rewirte.line.points3.Count - 1);
                        spdlist.RemoveAt(spdlist.Count - 1);
                    }
                }
                Vector2 startpos = rewirte.line.points3.Last();
                Vector2 mappos = new Vector2(Map.worldToMapX(startpos.x), Map.worldToMapY(startpos.y));
                Vector2 vel = spdlist.Last();
                float childbaseangle = 5.729572358572f;
                if(WeaponSelector.instance.selInd == 2)
                {
                    for (int i = -4; i < 5; i++)
                    {
                        Vector2 vel1 = vel.Rotate(childbaseangle * i);
                        CalculateLineNORMAL(mappos, vel1, acc);
                    }
                }
                else if (WeaponSelector.instance.selInd == 0)
                {
                    Vector2 vel1 = vel.Rotate(childbaseangle * -2f);
                    Vector2 vel2 = vel.Rotate(childbaseangle * 2f);
                    CalculateLineNORMAL(mappos, vel1, acc);
                    CalculateLineNORMAL(mappos, vel2, acc);
                }
                else if (WeaponSelector.instance.selInd == 1)
                {
                    Vector2 vel1 = vel.Rotate(childbaseangle * -1f);
                    Vector2 vel2 = vel.Rotate(childbaseangle * 1f);
                    Vector2 vel3 = vel.Rotate(childbaseangle * -3f);
                    Vector2 vel4 = vel.Rotate(childbaseangle * 3f);
                    CalculateLineNORMAL(mappos, vel1, acc);
                    CalculateLineNORMAL(mappos, vel2, acc);
                    CalculateLineNORMAL(mappos, vel3, acc);
                    CalculateLineNORMAL(mappos, vel4, acc);
                }

            }
            else if (WeaponSelector.instance.selFam.key == "jump" && false)
            {
                int[] part = { 4, 6, 8 };
                TracerLine rewirte = CalculateLineNORMAL(position, speed, acc);
                for (int i = 0; i < 15; i++)
                {
                    rewirte.line.points3.RemoveAt(rewirte.line.points3.Count - 1);
                }
                float rotbase = (float)((rewirte.line.points3.Count - 1) * -1f * power * velBase * Mathf.Sin(dAngle * Mathf.Deg2Rad));
                debugmessage = Environment.NewLine + rewirte.line.points3.Count + "|||||";
                Vector2 basespeed = new Vector2(0f, 2.8f);
                for (int i = 0; i < part[WeaponSelector.instance.selInd]; i++)
                {
                    Vector2 mappos = new Vector2(Map.worldToMapX(rewirte.line.points3.Last().x), Map.worldToMapY(rewirte.line.points3.Last().y));
                    CalculateLineNORMAL(mappos, basespeed.Rotate((360f / part[WeaponSelector.instance.selInd]) * (float)i + rotbase), acc);
                }
            }
            else if (WeaponSelector.instance.selFam.key == "napalm"&& (WeaponSelector.instance.selInd==0 || WeaponSelector.instance.selInd == 1))
            {
                List<Vector2> spdlist = new List<Vector2>();
                TracerLine rewirte = CalculateLineSPEED(position, speed, acc, ref spdlist);
                Vector2 startpos =  rewirte.line.points3.ElementAt(rewirte.line.points3.Count-31);
                Vector2 mappos = new Vector2(Map.worldToMapX(startpos.x), Map.worldToMapY(startpos.y));
                Vector2 vel = spdlist.ElementAt(rewirte.line.points3.Count - 31);
                float childbaseangle = 2.8647861f;
                for(int i = 1; i < 6; i++)
                {
                    Vector2 vel1 = vel.Rotate(childbaseangle * i);
                    CalculateLineNORMAL(mappos, vel1, acc);
                    Vector2 vel2 = vel.Rotate(childbaseangle * i * -1f);
                    CalculateLineNORMAL(mappos, vel2, acc);
                }
            }
            else
            {
                CalculateLineNORMAL(position, speed, acc);
            }
            foreach (TracerLine tr in linelist)
            {
                tr.line.Draw3D();
            }
        }
        private void gear()
        {

        }
        private void DrawCircle(Vector2 pos, float rad, float linewidth)
        {
            TracerLine ring = new TracerLine(new VectorLine("tracer", new List<Vector3>(), linewidth, LineType.Continuous), new Color(1, 1, 0, 1));
            linelist.Add(ring);
            Vector2 radius = new Vector2(0f, rad);
            for (int i = 0; i < 181; i++)
            {
                Vector2 temp = pos + radius;
                Vector3 newpos = new Vector3(Map.toWorldX(temp.x), Map.toWorldY(temp.y));
                ring.line.points3.Add(newpos);
                radius = radius.Rotate(2);
            }
        }
        // Calculate line 
        private TracerLine CalculateLineSPEED(Vector2 position, Vector2 speed, Vector2 acc,ref List<Vector2> speedlist)
        {
            TracerLine tracer = CreateTracerline(0f, 1f, 0f, 1f);
            linelist.Add(tracer);
            Vector2 lp = position;
            Vector3 start = new Vector3(Map.toWorldX(position.x), Map.toWorldY(position.y));
            tracer.line.points3.Add(start);
            while (true)
            {
                position += speed;
                speed += acc;
                CheckCollision(ref position, ref speed, acc, lp, ref tracer);
                position = CheckPortal(position);
                Vector3 point = new Vector3(Map.toWorldX(position.x), Map.toWorldY(position.y));
                speedlist.Add(speed);
                tracer.line.points3.Add(point);
                if (position.x > 1000f || position.x < 0 || position.y < Map.mapY(position.x))
                {
                    return tracer;
                }
                lp = position;
            }
        }
        private void CalculateLineUNDERGROUND(Vector2 position, Vector2 speed, Vector2 acc)
        {
            TracerLine tracer = CreateTracerline(1f, 0f, 0f, 1f);
            Vector2 FloorGravity = new Vector2(acc.x, 0.0783999973297119f);
            linelist.Add(tracer);
            Vector2 lp = position;
            Vector3 start = new Vector3(Map.toWorldX(position.x), Map.toWorldY(position.y));
            tracer.line.points3.Add(start);
            while (true)
            {
                position += speed;
                speed += FloorGravity;
                CheckCollision(ref position, ref speed, acc, lp, ref tracer);
                position = CheckPortal(position);
                Vector3 point = new Vector3(Map.toWorldX(position.x), Map.toWorldY(position.y));
                tracer.line.points3.Add(point);
                if (position.x > 1000f || position.x < 0 || position.y > Map.mapY(position.x))
                {
                    break;
                }
                lp = position;
            }
        }
        private void CalculateLineUNDERCHECK(ref Vector2 position, ref Vector2 speed, Vector2 acc)
        {
            TracerLine tracer = CreateTracerline(0f, 1f, 0f, 1f);
            linelist.Add(tracer);
            Vector2 lp = position;
            Vector3 start = new Vector3(Map.toWorldX(position.x), Map.toWorldY(position.y));
            tracer.line.points3.Add(start);
            while (true)
            {
                position += speed;
                speed += acc;
                CheckCollision(ref position, ref speed, acc, lp, ref tracer);
                position = CheckPortal(position);
                Vector3 point = new Vector3(Map.toWorldX(position.x), Map.toWorldY(position.y));
                tracer.line.points3.Add(point);
                if (position.x > 1000f || position.x < 0)
                {
                    break;
                }
                else if(position.y < Map.mapY(position.x))
                {
                    CalculateLineUNDERGROUND(position, speed, acc);
                    break;
                }
                lp = position;
            }
        }
        private void CalculateLineFLOORCHECK(ref Vector2 position, ref Vector2 speed, Vector2 acc)
        {
            TracerLine tracer = CreateTracerline(0f, 1f, 0f, 1f);
            linelist.Add(tracer);
            Vector2 lp = position;
            Vector3 start = new Vector3(Map.toWorldX(position.x), Map.toWorldY(position.y));
            tracer.line.points3.Add(start);
            while (true)
            {
                position += speed;
                speed += acc;
                CheckCollision(ref position, ref speed, acc, lp, ref tracer);
                position = CheckPortal(position);
                Vector3 point = new Vector3(Map.toWorldX(position.x), Map.toWorldY(position.y));
                tracer.line.points3.Add(point);
                if (position.x > 1000f || position.x < 0)
                {
                    break;
                }
                else if (position.y < Map.mapY(position.x))
                {
                    break;
                }
                lp = position;
            }
        }
        private TracerLine CalculateLineNORMAL(Vector2 position, Vector2 speed, Vector2 acc)
        {
            TracerLine tracer = CreateTracerline(0f, 1f, 0f, 1f);
            linelist.Add(tracer);
            Vector2 lp = position;
            Vector3 start = new Vector3(Map.toWorldX(position.x), Map.toWorldY(position.y));
            tracer.line.points3.Add(start);
            while (true)
            {
                position += speed;
                speed += acc;
                CheckCollision(ref position, ref speed, acc, lp, ref tracer);
                position = CheckPortal(position);
                Vector3 point = new Vector3(Map.toWorldX(position.x), Map.toWorldY(position.y));
                tracer.line.points3.Add(point);
                if (position.x > 1000f || position.x < 0 || position.y < Map.mapY(position.x))
                {
                    return tracer;
                }
                lp = position;
            }
        }
        private TracerLine CalculateLineNORMALT(Vector2 position, Vector2 speed, Vector2 acc)
        {
            TracerLine tracer = CreateTracerline(0f, 1f, 0f, 1f);
            linelist.Add(tracer);
            Vector2 lp = position;
            Vector3 start = new Vector3(Map.toWorldX(position.x), Map.toWorldY(position.y));
            tracer.line.points3.Add(start);
            while (true)
            {
                position += speed;
                speed += acc;
                CheckCollision(ref position, ref speed, acc, lp, ref tracer);
                position = CheckPortal(position);
                Vector3 point = new Vector3(Map.toWorldX(position.x), Map.toWorldY(position.y));
                tracer.line.points3.Add(point);
                if (position.x > 1000f || position.x < 0 || position.y < 0)
                {
                    return tracer;
                }
                lp = position;
            }
        }
        private TracerLine CalculateLineNORMALTTS(Vector2 position, Vector2 speed, Vector2 acc)
        {
            TracerLine tracer = CreateTracerline(0f, 1f, 0f, 1f);
            linelist.Add(tracer);
            Vector2 lp = position;
            Vector3 start = new Vector3(Map.toWorldX(position.x), Map.toWorldY(position.y));
            tracer.line.points3.Add(start);
            int times = 0;
            while (true)
            {
                position += speed;
                speed += acc;
                CheckCollision(ref position, ref speed, acc, lp, ref tracer);
                position = CheckPortal(position);
                Vector3 point = new Vector3(Map.toWorldX(position.x), Map.toWorldY(position.y));
                tracer.line.points3.Add(point);
                if (position.x > 1000f || position.x < 0 || position.y < 0||times>11)
                {
                    return tracer;
                }
                else if(position.y < Map.mapY(position.x))
                {
                    times++;
                }
                lp = position;
            }
        }
        private void CalculateLineCHILD(Vector2 position, Vector2 speed, Vector2 acc, int stime, int ttime, Vector2 childSpeed)
        {
            TracerLine tracer = CreateTracerline(0f, 1f, 0f, 1f);
            int ticktime = 0;
            linelist.Add(tracer);
            Vector2 lp = position;
            Vector3 start = new Vector3(Map.toWorldX(position.x), Map.toWorldY(position.y));
            tracer.line.points3.Add(start);
            while (true)
            {
                if ((ticktime - stime) % ttime == 0 && ticktime >= stime)
                {
                    Vector2 childacc = new Vector2(acc.x, (float)velYBase);
                    Vector2 chspeed;
                    if (speed.x >= 0f)
                    {
                        chspeed = new Vector2(Mathf.Abs(childSpeed.x), childSpeed.y);
                    }
                    else
                    {
                        chspeed = new Vector2(Mathf.Abs(childSpeed.x) * -1f, childSpeed.y);
                    }
                    CalculateLineNORMAL(position, chspeed, childacc);
                }
                position += speed;
                speed += acc;
                CheckCollision(ref position, ref speed, acc, lp, ref tracer);
                if (WeaponSelector.instance.selFam.key == "gull")
                {
                    CheckGullBounce(ref position, ref speed, acc, lp, ref tracer);
                }
                position = CheckPortal(position);
                Vector3 point = new Vector3(Map.toWorldX(position.x), Map.toWorldY(position.y));
                tracer.line.points3.Add(point);
                if (position.x > 1000f || position.x < 0 || position.y < Map.mapY(position.x))
                {
                    break;
                }
                lp = position;
                ticktime++;
            }
        }
        private void CalculateLineTOPCHECK(ref Vector2 position, ref Vector2 speed, Vector2 acc)
        {
            TracerLine tracer = CreateTracerline(0f, 1f, 0f, 1f);
            linelist.Add(tracer);
            Vector2 lp = position;
            Vector3 start = new Vector3(Map.toWorldX(position.x), Map.toWorldY(position.y));
            tracer.line.points3.Add(start);
            while (true)
            {
                if (speed.y < 0 && speed.y-acc.y > 0) break;
                position += speed;
                speed += acc;
                CheckCollision(ref position, ref speed, acc, lp, ref tracer);
                position = CheckPortal(position);
                Vector3 point = new Vector3(Map.toWorldX(position.x), Map.toWorldY(position.y));
                tracer.line.points3.Add(point);
                if (position.x > 1000f || position.x < 0 || position.y < Map.mapY(position.x)) break;
                lp = position;
            }
        }
        private void CalculateLineLIMIT(ref Vector2 position, ref Vector2 speed, Vector2 acc, int limit)
        {
            TracerLine tracer = CreateTracerline(0f, 1f, 0f, 1f);
            linelist.Add(tracer);
            Vector2 lp = position;
            Vector3 start = new Vector3(Map.toWorldX(position.x), Map.toWorldY(position.y));
            tracer.line.points3.Add(start);
            for (int i = 0; i < limit; i++)
            {
                position += speed;
                speed += acc;
                CheckCollision(ref position, ref speed, acc, lp, ref tracer);
                position = CheckPortal(position);
                Vector3 point = new Vector3(Map.toWorldX(position.x), Map.toWorldY(position.y));
                tracer.line.points3.Add(point);
                if (position.x > 1000f || position.x < 0)
                {
                    break;
                }
                lp = position;
            }
        }
        private bool IsLineCollisionLine(Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4)
        {
            float x1 = p1.x, x2 = p2.x, x3 = p3.x, x4 = p4.x;
            float y1 = p1.y, y2 = p2.y, y3 = p3.y, y4 = p4.y;

            float d = (x1 - x2) * (y3 - y4) - (y1 - y2) * (x3 - x4);
            // If d is zero, there is no intersection
            if (d == 0)
                return false;

            // Get the x and y
            float pre = (x1 * y2 - y1 * x2), post = (x3 * y4 - y3 * x4);
            float x = (pre * (x3 - x4) - (x1 - x2) * post) / d;
            float y = (pre * (y3 - y4) - (y1 - y2) * post) / d;

            // Check if the x and y coordinates are within both lines
            if (x < MIN(x1, x2) || x > MAX(x1, x2) ||
                x < MIN(x3, x4) || x > MAX(x3, x4))
                return false;

            if (y < MIN(y1, y2) || y > MAX(y1, y2) ||
                y < MIN(y3, y4) || y > MAX(y3, y4))
                return false;

            return true;
        }
        private float MIN(float a, float b)
        {
            if (a >= b) return b;
            else return a;
        }
        private float MAX(float a, float b)
        {
            if (a >= b) return a;
            else return b;
        }
        private Vector2 intersection(Vector2 u1, Vector2 u2, Vector2 v1, Vector2 v2)
        {
            Vector2 ret = u1;
            double t = ((u1.x - v1.x) * (v1.y - v2.y) - (u1.y - v1.y) * (v1.x - v2.x))
              / ((u1.x - u2.x) * (v1.y - v2.y) - (u1.y - u2.y) * (v1.x - v2.x));
            ret.x += (float)((u2.x - u1.x) * t);
            ret.y += (float)((u2.y - u1.y) * t);
            return ret;
        }
        private void CheckCollision(ref Vector2 point, ref Vector2 speed, Vector2 acc, Vector2 lp, ref TracerLine collline)
        {
            if (bumperlock&&checkbumperlimit<100)
            {
                if (lp.x > 0f && point.x <= 0f)
                {
                    PointF inp = Collisions.Intersects(new Segment(new PointF(lp.x, lp.y), new PointF(point.x, point.y)), new Segment(new PointF(leftp1.x, leftp1.y), new PointF(leftp2.x, leftp2.y)));
                    if (inp != null)
                    {
                        point = new Vector2(inp.X, inp.Y);
                        speed = Vector2.Reflect(speed, (leftp2 - leftp1).normalized.Rotate(90f));
                        collline.line.points3.Add(new Vector3(Map.toWorldX(point.x), Map.toWorldY(point.y)));
                        point += speed;
                        speed += acc;
                        collline.line.points3.Add(new Vector3(Map.toWorldX(point.x), Map.toWorldY(point.y)));
                        checkbumperlimit++;
                    }
                }
                if (lp.x < 1000f && point.x >= 1000f)
                {
                    PointF inp = Collisions.Intersects(new Segment(new PointF(lp.x, lp.y), new PointF(point.x, point.y)), new Segment(new PointF(rightp1.x, rightp1.y), new PointF(rightp2.x, rightp2.y)));
                    if (inp != null)
                    {
                        point = new Vector2(inp.X, inp.Y);
                        speed = Vector2.Reflect(speed, (rightp2 - rightp1).normalized.Rotate(-90f));
                        collline.line.points3.Add(new Vector3(Map.toWorldX(point.x), Map.toWorldY(point.y)));
                        point += speed;
                        speed += acc;
                        collline.line.points3.Add(new Vector3(Map.toWorldX(point.x), Map.toWorldY(point.y)));
                        checkbumperlimit++;
                    }
                }
                foreach (Prop_Bumper p in bumperlist)
                {
                    float rot = 0f;
                    if (p.rot < 0)
                    {
                        rot = 180 + p.rot;
                    }
                    else
                    {
                        rot = p.rot;
                    }
                    Vector2 p1 = new Vector2(p.x - p.len / 2f * Mathf.Sin(rot * Mathf.Deg2Rad), p.y + p.len / 2f * Mathf.Cos(rot * Mathf.Deg2Rad));
                    Vector2 p2 = new Vector2(p.x + p.len / 2f * Mathf.Sin(rot * Mathf.Deg2Rad), p.y - p.len / 2f * Mathf.Cos(rot * Mathf.Deg2Rad));
                    Vector2 bumper = p2 - p1;
                    PointF inp = Collisions.Intersects(new Segment(new PointF(lp.x, lp.y), new PointF(point.x, point.y)), new Segment(new PointF(leftp1.x, leftp1.y), new PointF(leftp2.x, leftp2.y)));

                    if (IsLineCollisionLine(p1, p2, lp, point))
                    {
                        if (Vector2.Angle(speed.normalized, (p2 - p1).normalized) >= 90f)
                        {
                            speed = Vector2.Reflect(speed, (p2 - p1).normalized.Rotate(-90f));
                        }
                        else
                        {
                            speed = Vector2.Reflect(speed, (p2 - p1).normalized.Rotate(-90f));
                        }
                        point = intersection(p1, p2, lp, point);
                        collline.line.points3.Add(new Vector3(Map.toWorldX(point.x), Map.toWorldY(point.y)));
                        point += speed;
                        speed += acc;
                        collline.line.points3.Add(new Vector3(Map.toWorldX(point.x), Map.toWorldY(point.y)));
                        checkbumperlimit++;
                    }
                }
                foreach (Prop_CBumper p in cbumperlist)
                {

                    Vector2 Cbumper = new Vector2((float)p.x, (float)p.y);
                    Vector2 cbnormal = point - Cbumper;
                    if (Collisions.CirclePoint(p.x, p.y, p.rad, point.x, point.y))
                    {
                        Vector2 tempspeed = Vector2.zero;
                        Vector2 temp = speed - acc;
                        for (float j = 0f; j <= 1f; j += booster)
                        {
                            cbnormal = lp + temp * j - Cbumper;
                            if (cbnormal.magnitude <= (float)p.rad - cbrplus)
                            {
                                drawline(Cbumper, lp + temp * j);
                                speed = Vector2.Reflect(speed, cbnormal.normalized);
                                point = lp + temp * j;
                                collline.line.points3.Add(new Vector3(Map.toWorldX(point.x), Map.toWorldY(point.y)));
                                point += speed * (1f - j);
                                speed += acc;
                                collline.line.points3.Add(new Vector3(Map.toWorldX(point.x), Map.toWorldY(point.y)));
                                checkbumperlimit++;
                                break;
                            }
                        }
                    }
                }
            }
        }
        private void drawline(Vector2 start,Vector2 end)
        {
            TracerLine t1 = CreateTracerline(1f, 0.5f, 1f, 1f);
            linelist.Add(t1);
            t1.line.points3.Add(new Vector3(Map.toWorldX(start.x), Map.toWorldY(start.y)));
            t1.line.points3.Add(new Vector3(Map.toWorldX(end.x), Map.toWorldY(end.y)));
        }
        private void CheckGullBounce(ref Vector2 point, ref Vector2 speed, Vector2 acc, Vector2 lp, ref TracerLine collline)
        {
            if (lp.x > 0f && point.x <= 0f)
            {
                PointF inp = Collisions.Intersects(new Segment(new PointF(lp.x, lp.y), new PointF(point.x, point.y)), new Segment(new PointF(leftp1.x, leftp1.y), new PointF(leftp2.x, leftp1.y + 5000f)));
                if (inp != null)
                {
                    point = new Vector2(inp.X, inp.Y);
                    speed = Vector2.Reflect(speed, (leftp2 - leftp1).normalized.Rotate(90f));
                    collline.line.points3.Add(new Vector3(Map.toWorldX(point.x), Map.toWorldY(point.y)));
                    point += speed;
                    speed += acc;
                    collline.line.points3.Add(new Vector3(Map.toWorldX(point.x), Map.toWorldY(point.y)));
                }
            }
            if (lp.x < 1000f && point.x >= 1000f)
            {
                PointF inp = Collisions.Intersects(new Segment(new PointF(lp.x, lp.y), new PointF(point.x, point.y)), new Segment(new PointF(rightp1.x, rightp1.y), new PointF(rightp2.x, rightp1.y + 5000f)));
                if (inp != null)
                {
                    point = new Vector2(inp.X, inp.Y);
                    speed = Vector2.Reflect(speed, (rightp2 - rightp1).normalized.Rotate(-90f));
                    collline.line.points3.Add(new Vector3(Map.toWorldX(point.x), Map.toWorldY(point.y)));
                    point += speed;
                    speed += acc;
                    collline.line.points3.Add(new Vector3(Map.toWorldX(point.x), Map.toWorldY(point.y)));
                }
            }
        }
        private Vector2 CheckPortal(Vector2 point)
        {
            foreach (Prop_Portal p in portallist)
            {
                Vector2 port1 = new Vector2(point.x - p.x1, point.y - p.y1);
                Vector2 port2 = new Vector2(point.x - p.x2, point.y - p.y2);

                if (port1.magnitude <= p.rad && lockport == 0)
                {
                    lockport = 1;
                    point.x += p.x2 - p.x1;
                    point.y += p.y2 - p.y1;
                }
                else if (port2.magnitude >= p.rad + 1f && lockport == 1)
                {
                    lockport = 0;
                }
                else if (port2.magnitude <= p.rad && lockport == 0)
                {
                    lockport = 2;
                    point.x += p.x1 - p.x2;
                    point.y += p.y1 - p.y2;
                }
                else if (port1.magnitude >= p.rad + 1f && lockport == 2)
                {
                    lockport = 0;
                }
            }
            return point;
        }
        private Vector2 CheckFloor(Vector2 lp, Vector2 p)
        {
            float tempx = (lp.x - p.x) / 1000f;
            float tempy = (lp.y - p.y) / 1000f;
            for (int i = 0; i < 1001; i++)
            {
                if ((lp.y - tempy * i - Map.mapY(lp.x - tempx * i)) < 0.000001)
                {
                    Vector2 rep = new Vector2(lp.x - tempx * i, Map.mapY(lp.x - tempx * i));
                    return rep;
                }
            }
            return Vector2.zero;
        }
        private bool tunnelCheck()
        {
            bool tunnelcheck = false;
            if (WeaponSelector.instance.selFam.key == "snipe" && WeaponSelector.instance.selInd == 1)
            {
                tunnelcheck = true;
            }
            else if (WeaponSelector.instance.selFam.key == "tunnel" && (WeaponSelector.instance.selInd == 0 || WeaponSelector.instance.selInd == 1 || WeaponSelector.instance.selInd == 3))
            {
                tunnelcheck = true;
            }
            else if (WeaponSelector.instance.selFam.key == "penetrate")
            {
                tunnelcheck = true;
            }
            return tunnelcheck;
        }
        private TracerLine CreateTracerline(float red = 0f, float green = 1f, float blue = 0f, float alpha = 1f, float width = 1f)
        {
            TracerLine ret = new TracerLine(new VectorLine("tracer", new List<Vector3>(), width, LineType.Continuous), new Color(red, green, blue, alpha));
            return ret;
        }
        void OnGUI()
        {
            GUI.Label(new Rect(10, 25, 1600, 700), debugmessage + OverlayString);
        }
        private String debugmessage = "";
        private bool CreaterLock = false;
    }
}
