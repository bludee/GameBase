# 使用流程
* 用fgui做一个界面,在Script/View/Panel/中创建对应的panel,可以参看StartPanel,在GameRoot中调用这个Panel就可以了
# 简介
* GameRoot 初始化各个管理器,管理器会在Awake时执行Init方法 GameRoot中开始调用第一个面板,之后开始游戏逻辑,所有第三方的东西,都在这之前初始化 包括UI,统计sdk,广告sdk等等
* AppMain 游戏的全局管理器索引,所有的管理器都通过AppMain.Inst来获取,具体可以查看该类,添加和删除Mgr都在该类中
* AppMain中当前具有:Config,Socket,Sound,Resources,Game,Model,ObjectPool,Save,ViewMgr等具体功能可以直接在对应类中添加,所有引用都通过AppMian.Inst.XXMgr.XXX() 调用
* ViewMgr UI面板管理,包括获取面板,判断面板是否存在,自动加载卸载UIpackage.引用计数等
* BasePanel 面板基类,封装了常用方法,继承自FUI的Window

# 事件机制
* Scripts/Framework/Message 
* 使用方法  GEventCenter<T>.Inst.DispatchEvent() AddEventListener  RemoveEventListener() 使用方法和AS3 一致,add后记得remove即可,事件参数是一个object对象.具体逻辑自己处理

# 游戏逻辑
* 一般都放在Game下,对应功能创建新包即可,单独功能的管理,用单例来实现即可
* Res/Config/ 放置json文件对应的类,然后在ConfigManager中注册,之后通过AppMainD调用





# Tools
* 对应版本的FGUI的编辑器和Excel转json脚本工具 需要python2.7环境 ,依赖库,按照运行时提示安装即可




