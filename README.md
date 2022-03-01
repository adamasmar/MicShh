# MicShh

For those who hate having to activate 10 different windows to mute yourself during a call.

## What is it?

It is a super basic WinForms application that enables a global mute/unmute of selected audio input devices.

## Why?

Because everything else I found either did too much or too little to accomplish the task I wanted of having a dedicated, configurable, global key bind to mute my microphone.

## How to use?

###### Installation
For now, you will need to download the repo, build the application in Release using something like Visual Studio. Place the entire ``bin\Release\net6.0-windows`` in a place that you like and run! You can also configure to run at Windows start if you so desire.

###### Interaction
On first load, the application will have a default key bind of `Win, Alt + K` (this is what the Windows 11 global mic mute key bind should be ... if it was working 😊). This can be modified using the _Record New Keybind_ button. You can indicate which input devices you would like to be targeted to be muted/unmuted by selecting them in the left window. Additionally, sound can be configured on or off using the _Use Sound?_ check box.

That's mostly it, hopefully everything else is intuitive enough!

## Screenshots
###### Main Screen
![image](https://user-images.githubusercontent.com/35544437/156086331-1eb3077f-b81a-4a04-a6ef-75036f5bc703.png)
###### Key bind record screen
![image](https://user-images.githubusercontent.com/35544437/156086671-1e42e66c-323d-4332-9588-0fe02ea13624.png)
###### App access from task bar
![image](https://user-images.githubusercontent.com/35544437/156086418-4c7b413f-59ef-46a4-bc60-10c162086b5e.png)
