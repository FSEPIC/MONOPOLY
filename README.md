# 大富翁游戏

# 需求分析与概要设计

 

## 1.  项目说明

## 1.1. 项目目标：

我们团队想要研发的是一款把校园生活融入游戏的一款游戏，大致的游戏机制我们打算使用大富翁的方式去实现。

## 1.2. 软硬件环境需求

操作系统：WIN10

数据库：无

网络要求：无

## 1.3. 使用的关键技术：

 

我们可能会使用unity来实验游戏的界面，但是我们大部分人都是尚未接触过unity的，所以我们需要在短短的时间内学习关于unity的一些知识来完善关于界面画面的实现，而且我们针对校园生活对游戏的形式和机制进行的改造，更加符合我们的观念。

在我们构思的时候我们需要许多的函数来实验事件的部分，后来我们想了一个办法来充实游戏的内容却不用实现许许多多不同的事件，我们觉得使用不用的文本提示来让玩家以为触发了不同的效果，但是实际上我们其中的实现函数还是同一个。

 

## 2.  需求分析

## 2.1. 系统用例

![img](file:////Users/epicfs/Library/Group%20Containers/UBF8T346G9.Office/TemporaryItems/msohtmlclip/clip_image002.jpg)

（图一用例图）

用例描述：

自定义游戏：开始新游戏之前设置游戏的属性，包括游戏人数和使用的地图。

设置人数：设置参与游戏的玩家人数。

选择地图：选择游戏使用的地图。

进行游戏：游戏的主体部分，实现游戏内的主要功能。

移动：玩家根据获得点数移动响应步数。

掷骰子：玩家通过掷一枚骰子获得移动点数（1~6）。

使用道具：玩家使用获得的金币或特数道具。

触发事件：玩家在走到事件格子时会触发特殊事件，对自己或其他玩家产生特殊效果。

保存游戏：玩家保存未进行完的游戏。

 

## 2.2. 业务流程

游戏初始化设定活动图：

![img](file:////Users/epicfs/Library/Group%20Containers/UBF8T346G9.Office/TemporaryItems/msohtmlclip/clip_image004.jpg)

行动阶段活动图：

![img](file:////Users/epicfs/Library/Group%20Containers/UBF8T346G9.Office/TemporaryItems/msohtmlclip/clip_image006.jpg)

 

结算阶段行动图：

![img](file:////Users/epicfs/Library/Group%20Containers/UBF8T346G9.Office/TemporaryItems/msohtmlclip/clip_image008.jpg)

 

## 3.  概要设计

## 3.1. 功能模块设计

​    ![img](file:////Users/epicfs/Library/Group%20Containers/UBF8T346G9.Office/TemporaryItems/msohtmlclip/clip_image010.jpg)

 1开始游戏

  I:选择的游戏规则、地图、模式、人数

 O：初始化游戏

 主要功能：玩家自定义游戏的各种规则，开始一场新的游戏

 2读档

  I：存档编号

  主要功能：从本地文件里读取数据，继续一场游戏

  3、地图界面

  主要功能：游戏的主要场景，实现人物的走步，以及包含大部分菜单的功能

  4、事件系统

 I：人物所在的坐标

  O：触发的事件以及产生的结果

  5、道具系统

  I：使用or获得、物品编号

  O：物品数量的改变、产生的效果带来的结果

  功能：负责所有有关道具的操作、时间，并产生相应的效果，以及放出相应的特效

  6、情报查询系统

  I：玩家需要查询的数据类型、玩家编号

  O：金币、道具等相应的信息

  功能：帮助玩家了解大局以及其他玩家的概况，分析局势

  7、存档

  I：当前游戏的所有数据

  O、存档文件

  8、结算

  I：玩家的各项游戏数据

  O：玩家的表现评分

## 3.2核心类图

![img](file:////Users/epicfs/Library/Group%20Containers/UBF8T346G9.Office/TemporaryItems/msohtmlclip/clip_image012.jpg)

本图不代表最终程式

 

## 4.界面设计

（不代表最终版本）

开始界面：

![img](file:////Users/epicfs/Library/Group%20Containers/UBF8T346G9.Office/TemporaryItems/msohtmlclip/clip_image014.jpg)

游戏界面：

![img](file:////Users/epicfs/Library/Group%20Containers/UBF8T346G9.Office/TemporaryItems/msohtmlclip/clip_image016.jpg)

 

结算界面：

![img](file:////Users/epicfs/Library/Group%20Containers/UBF8T346G9.Office/TemporaryItems/msohtmlclip/clip_image018.jpg)

## 5.基本代码分工
闫顺兴：事件设定、触发与执行逻辑

张文喆：地图设计、事件触发执行与UI逻辑行为绑定

陈威：逻辑与UI绑定、UI逻辑行为实现

徐明睿：事件设定、触发与执行逻辑

王浩欢：事件设定、触发与执行逻辑
