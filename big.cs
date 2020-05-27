@startuml
skinparam classAttributeIconSize 0

class people{
    -Name : String 玩家姓名
    -Id : Int 区别玩家
    -GradeAt : Int[7] 存储各科属性
    -ispause : Bool[10] 停止几回合，全true则可以行动
    -hmgf : Int 几任女朋友
    -Props : Bool[m] m为道具种类
    +Money : Int 钱
    +Int pause() : 还有多少回合需要暂停
    +void addpause() : 添加暂停回合
    +Int[] getGrade() : 获得科目属性
    +void addGrade() : 添加科目属性
    +Int getID() : 获取ID
    ....可添加其他属性或函数丰富功能
}

class game{
    +void stars() : 开始游戏
    +void endgame() : 结束游戏
}

class event{
    -eventname : hash[v,k] 通过随机数产生不同的值，值为文本信息
    +void eventhapp() : 内涵swich函数，对应随机数而触发函数
    -void something1() : 用来嵌套在eventhapp中
    -void something2() : ....
    ....可添加辅助函数来完成各种花样功能
}

class helpfunc{
    +Int random() : 给予范围返回范围内随机数
    ....自行添加
}
class Map{
    -players : people[n] 构造时添加玩家数量
    -Bool MG() : 监控全局,表示玩家是否完成一圈，决定何时结束游戏
    -Int[] end(): 结束时结算的函数
    +void addGradeinmap() : 触发该函数会给某位玩家添加相应科目的属性
    +void move() : 玩家移动函数. 交给实现控件绑定的负责人
    ....
}
Map "1"-->"n" people
event ..> helpfunc
game o-- Map : have 1 >
game o-- helpfunc: have 1 >
game o-- event: have 1 >
game o-- people: have n >
@enduml