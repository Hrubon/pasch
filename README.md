# $(NAME)

**Disclaimer: This is source code of school work that is still in development. Repository does not contain finished and tested software work. If you decide to use this code, you do so on your own risk.**

## Overview

$(NAME) is open-source software solution of PA audio system, inteded primarily for usage in school environment that uses Microsoft Windows. The system is designed to be distributed over a network -- it consists of many client parts and one server part. All tasks related to PA system usage are initiated by any of the clients and delegated to the server. The server is supposed to have a sound card connected to PA system amplifier. Clients are supposed to have a microphone connected to PC.

TODO: Image diagram

## Philosophy

Even if someone could tell this contradiction, this is open-source software written in C# .NET for Microsoft Windows. I have written it from scratch when I was network administrator of a high school. Microsoft Windows is de facto standard OS in today schools (at least in Czech Republic), thus selection of C# as a programming language seems as reasonable choice.

In school environment, money budgeting can be an issue, especially in the area of software investition. In many cases, even if the purchased software is well-written and maintained, the software usually lacks some of the key features and/or interfaces. Software designers often concetrate on the implementation of software features itself and forgot that the software is supposed to be running in some environment, and thus should be able to be easily integrated into that environment. Then it could be real pain for network administrators to glue all this software together with existing infrastrucuture. Finally administrators are forced to accept lots of inappropriate compromises and half-way solutions that do not fit the usecase.

For network administrators it should not be hard to write a piece of code to slightly customize behaviour of some program. Often minor invention can have a big impact on the quality of overall solution. The problem is that if the software is closed, administrators do not have a chance to customize it anyway. $(NAME) aims to be as open as possible for customization. First, it is an open-source. Second, it tries to consistently separate the interface of important components of the software from the implementation. As a result, the implementation of such components can be provided by third parties -- e. g. by the administrators. These components can be, for example, authentication or database backend. Also predefined alternative implementations of the components will be included in the repository, which makes eventuall customization even easier.

## Features

### List of current features:
* Live broadcasting of announcements to PA system
* Planing of pre-recorded announcements to be played at specific time
* Planing of MP3 audio files to be played at specific time
* Administering of planed announcements (editation, deletion)
* Advanced authentication and authorization of users using LDAP
* Encryption of TCP messages
* Server is able to run both as a Windows service or as a console application (for debugging purposes)
* Simple log is produced by the server

### Wishlist:
* Refactoring of current implementation, including:
    * Reduction of server resources usage and eventuall security holes (limit number of clients and threads, etc.)
    * Consolidation of the protocol (return codes, etc.)
    * Try to reduce latency of live audio streaming
    * Restructuralize some of current code
* Write high-quality database backend implementations (MySQL, MS-SQL and SQLite variants)
* Write more authentication and authorization backend implementations (RADIUS, Database)
* Add full support for server certificate exchange instead of public key exchange in crypto module
* Add approvement procedure of planed announcements by supervisor
* Enhance announcement planing by input of repeated events easily
* Enhance announcement planing GUI by calendar view
* Improve announcement policying
* Improve server loging to be customizable (predefined support for BSD Syslog) and introduce client logging
* Compile client installation package for easy deployment