# iFunny-Basic-Auth-Generator
A C# version of iFunny's Basic Auth Generator

A Basic auth token in iFunny's case is a token which is generated after installing and opening the app for the first time. It is used by iFunny to make sure you are accessing the app on a mobile device and also as a unique device identifier for your device. By generating your own auth token you can spoof a random mobile device which will allow you to access iFunny services without using the app and being able to unlink your account from a device comes as a bonus.

How to use: Simply run the program and it will give you a valid basic auth token. It may not work on first or second try so be sure to try to login atleast 3 times. After that it will work on the first try.
