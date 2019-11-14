namespace TeamTube
{
    public enum TileType
    {
        Wall,
        floor,
        entrance,
        exit,
        error
    }
    enum GameState
    {
        mainMenu,
        gamePlay,
        moveSelect,
        itemSelect,
        pauseMenu,
        winState,
        gameOver
    }
    enum MenuState//Item state will be put in at a later time
    {
        attack,
        strongAttack,
        item,
        exit
    }
    enum ItemState
    {
        bomb,
        potion,
        exit
    }
}
