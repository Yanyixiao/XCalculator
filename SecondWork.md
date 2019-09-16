Git地址|~~~
--|--
Git用户名|
学号后五位|23225
博客地址|https://www.cnblogs.com/xiaoxiao0331/
作业链接|https://www.cnblogs.com/harry240/p/11515697.html
-----
### 一、预先准备工作
##### Part 0. 程序需求
+ 程序接收一个参数  **n**  随机产生  **n**  道包含  **四则运算**  的练习题，数字在  **0-100** 之间，运算符为 **2** 或者 **3** 个。
+ 程序运算过程中不得出现分数，运算过程中与结果中都不可以出现。
+ 练习题生成好后，将生成的 **n** 道练习题及其对应答案输出至文件 **Subject.txt** 中。

##### Part 1. 配置环境
+ 几个月前我的电脑已经安装好Visual Studio 2019 Preview，不再赘述。
  
### 二、克隆项目
##### Part 2.克隆项目
+ Step 1.注册Github账号，已有不再赘述。
+ Step 2.成功登录后，输入[阿超仓库的网址](https://github.com/Cherish599/AchaoCalculator),点击右上角Fork，拷贝到自己的同名仓库中。
+ Step 3.在桌面右键菜单中打开Git Bash命令行，输入
`git clone https://github.com/Yanyixiao/AchaoCalculator.git`，然后Enter。之后会发现桌面上多了一个同名文件夹。
+ 根据作业要求，不执行`git checkout cplusplus`。
+ 新建文件夹，命名为`Yanyixiao`
+ 启动VS2019时发现，2019自带签出代码功能诶。

##### Part 2.5 签下来的代码是Java的，还得自己写。。
+ 照着Java版本的Calculator写了好久，有一个问题还没解决，但是已经很饿了。（09152019 7:00pm）


##### Part 3.单元测试
+ Step 1.新建测试方案
  右键单击解决方案，可以添加一个新建项目，在类型里选择`单元测试`，我这里新建了一个名为 `UnitTestCalculator`的单元测试项目。
+ Step 2.添加引用
  右键新建的单元测试`引用`，选择项目`UnitTestCalculator`。


  
