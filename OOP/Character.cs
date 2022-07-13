namespace OOP {
    class Character { 

        public string Name {get;}
        public int health;

        public bool isDead {get => health <= 0; }
    }
}