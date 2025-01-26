/**
 * 4方向路点的寻路类型 只针对 45度路点 和 90度地图路点的寻路， 对六边形寻路无效。
 * @作者 落日故人 QQ 583051842
 */
 public enum PathQuadSeek 
 {
    /**
     * 4方向寻路
     * 
     * 寻路时只会检测上下左右4个路点  
     * 
     * 比如 ：
     *       o
     *      o*o    该形状就是4方向寻路，中间点每次寻路要检测上下左右4个路点
     *       o
     * 
     * 应用情况：一般经营类或农场类的游戏，有角色在场景里行走，使用4方寻路，或者个别策略游戏，需要角色严格按照横向和纵向行走的情况。
     * 当然使用4方向也不是必定的，游戏需求掌握在游戏制作者手里，是用4方向还是8方向寻路，由制作者决定
     */
    path_dire_4 = 0,

    /**
     * 8方向寻路 （属于4方向寻路的扩展）
     * 
     * 寻路时除了检测上下左右4个路点，还有4个对角线的路点，一共8个路点
     * 
     * 比如 ：
     *      ooo
     *      o*o    该形状就是8方向寻路，中间点每次寻路要检测周围8个路点
     *      ooo
     * 
     * 应用情况：一般使用于RPG，RTS游戏，还有个别策略游戏，8方寻路可以求得寻路路径最短的路径。
     * 
     */
    path_dire_8 = 1,


 }
 