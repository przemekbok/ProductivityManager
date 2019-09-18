Welcome in Productivity Manager for Windows

Maing goal of this app it to increase productivity when you're working on yours PC.

App is capable of:
1.Blocking wepsites for certain amount of time

IMPORTANT vvv
App uses 'etc/hosts' file to fulfill it's purpose.
'etc/hosts' is a text file which "act" as local DNS. You can place a line with an ip address and boinded to it domain name. Windows reads this file and if we want to connect to defined domain windows will reslove it as connection to given ip.
Bounding domain name to loopback (127.0.0.1 / localhost) will act like 'blocker' to a website cause it will never be reached (unless you are hosting webapp/webpage on localhost).
//This app generates unresloveable ip address for current session and binds blacklisted webpages to it, it won't affect your everyday usage of your's PC.

App need to run with admin privileges beacuse it operates on etc/hosts file which is protected file.
Don't worry about your config, app's records are marked with special hash that enables easy cleanup.

Modern web browsers are using proxy by default. Please check if your browser using one beacuse If it does then etc/hosts won't affect your connection.
Disable yours browser proxy if you want use main feature of this app. Remember, diffrent browsers configue proxy diffrent, some uses Windows defined proxies, some are using build in modules.
Disablingone one browser proxy in many cases won't affect proxies defined for other browsers. 
If you are having problem with yours browser proxy configuration feel free to google it :) I found step by step guides for chrome, ff, opera and ie with no problem.
IMPORTANT ^^^

Instructions:
1. Turn on app with admin privileges. App icon should appear in system tray.
2. Click an icon on system tray. Timer with a black list should appear.
3. Choose time span for your productive time, fill blacklist with distracting sites.
4. Click 'Start' to engage. Now websites should be blocked for choosen time span!
