# NetCoreDllPather
用于编译 .NET Core 程序的模块，可以将生成的可执行文件与DLL文件分离，将DLL文件单独放到程序目录中的文件夹中。  
Fork from https://github.com/HMBSbige/DotNetDllPathPatcher

# How to use
1)  复制src文件夹中的Build文件夹和build.ps1脚本到解决方案目录。   

2) 修改build.ps1  
记事本或任意编辑工具打开build.ps1，修改$app_name为你要编译发布的项目名称，默认项目在当前解决方案更目录下，且项目的.csproj文件名称与指定的项目名称相同。  

3) 执行build.ps1
在解决方案目录下执行`build.ps1`
```shell
build.ps1 {发布架构} {项目名称} [可选]"{忽略的文件或文件夹}"
```
exp:
```shell
.\build.ps1 win-x64 Sample.Mvc "wwwroot,appsettings.json"   #不要忘了引号
```

架构可选参数：all,platform,win-x86,win-x64,win-arm,linux-x64,linux-arm <br />


| 参数  | 说明  |
| :------------ | :------------ |
| all  | 生成以下全部架构  |
| platform  | 生成当前平台框架依赖  |
| win-x86  | win-x86  |
| win-x64  | win-x64  |
| win-arm  | win-arm 32位  |
| linux-x64  | linux-x64  |
| linux-arm  | linux-arm 32位  |

# Demo
![demo](https://github.com/withsalt/NetCoreDllPather/blob/main/img/demo.png "demo")  
