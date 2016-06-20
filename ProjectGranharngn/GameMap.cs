using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ProjectGranharngn
{
    public class GameMap : IEnumerable<IDrawable>
    {
       
        public List<IDrawable> gameObject;

        private Player controleObject;
        

        public GameMap() {

            gameObject = new List<IDrawable>();
            

            gameObject.Add(new Player(100, 5, 5, 2, 2, 5));
            gameObject.Add(new SteelWall(100, 1, 10, 10, 1));

            controleObject = GetControleObject();

            Interact += ControleObject.InteractHandler;
        }
        public Player ControleObject
        {
            get { return controleObject; }
        }

        

        public void UpdatePosition(object sender, KeyEventArgs e) {
           
            foreach (DrawingObject item in gameObject)
            {
                if (ControleObject.DrawRect.IntersectsWith(item.DrawRect) && ControleObject != item)
                {
                    Interact(this,EventArgs.Empty);
                }
            }
        }

        private Player GetControleObject(){
            string temp = new Player().ToString();
            foreach (DrawingObject item in gameObject)
            {
                if (temp == item.ToString())
                {
                    return (Player)item;
                }
            }
            return null;
        }

        public IEnumerator<IDrawable> GetEnumerator() {
            foreach (var item in gameObject)
            {
                yield return item;
            }
            //return gameObject.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public event EventHandler Interact;
    }

  
}
