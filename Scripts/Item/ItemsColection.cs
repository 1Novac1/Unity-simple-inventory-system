using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItemsCollection
{
    public class Apple : Item
    {
        public Sprite Sprite = Resources.Load<Sprite>("Sprites/Apple");

        public override bool IsStackable { get { return true; } }

        public override Sprite GetSprite()
        {
            return Sprite;
        }
        
        public Apple()
        {
            base.Amount = 1;
        }

        public Apple(int amount)
        {
            base.Amount = amount;
        }

        public override Item Clone() => new Apple { Amount = this.Amount }; // For a stackable item you need to clone its amount.
    }

    public class GoldenKey : Item
    {
        public Sprite Sprite = Resources.Load<Sprite>("Sprites/GoldenKey");

        public override bool IsStackable { get { return false; } }

        public override Sprite GetSprite()
        {
            return Sprite;
        }

        public GoldenKey()
        {
            base.Amount = 1;
        }
    }
}
