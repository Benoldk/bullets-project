namespace game.package.bullets
{
    public enum BulletFormation
    {
        Single,
        Line,
        Circle,
        /// <summary>
        /// From 3 to 12 sided polygons
        /// </summary>
        Polygon,
        /// <summary>
        /// Multiple emitters combined to create unique patterns
        /// </summary>
        Compound,
    }
}