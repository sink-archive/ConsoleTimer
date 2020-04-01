# ConsoleTimer
[![Travis CI Build Status](https://travis-ci.com/cainy-a/ConsoleTimer.svg?branch=master)](https://travis-ci.com/cainy-a/ConsoleTimer)
[![Appveyor Build status](https://ci.appveyor.com/api/projects/status/i347n94ptb0smy93?svg=true)](https://ci.appveyor.com/project/cainy-a/consoletimer)

ConsoleTimer is a timer built in C# on Monodevelop, and compiled with Mono.
It can work as:
- a stopwatch, counting up in hours:minutes:seconds indefinitely,
- or as a countdown timer, counting down until it reaches 0:0:0.0

## How to run this application.
### Windows
Just run it. That's all you need to know
### Supported Linux
For the following linux distributions, there is a native package available, just check the releases.
- Debian 9 (stretch) x64
### Mac and Unsupported Linux
If you have Wine (and preferably `wine-mono`) then you're good to go: just run `wine ConsoleTimer.exe`

If you have Mono, then you're good to go: just run `mono ConsoleTimer.exe`

If not, then download Wine from [their website](https://winehq.org),

or download Mono from [their website](https://mono-project.com), or the [Monodevelop website](https://monodevelop.com)

PS: This commit only exists to test GPG signing; there are no code changes