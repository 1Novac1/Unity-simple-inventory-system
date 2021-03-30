# Simple Inventory System

## Introduction

#### Inventory system allows to:

- Add/Remove items
- Drop/Spawn items

> Hint: Also you can create own items to use them.

## How it works

![](https://github.com/1Novac1/Unity_Simple-Inventory-System/blob/main/_source/gif_1.gif)

The lifted items are immediately added to the inventory respectively. To drop an item, simply right click on a slot in your inventory.

> Hint: In this example, there are 8 slots in the inventory, but you can increase their number to as many as you want.

## The item system in this project
In this example, there are `2` types of items:

- Stackable (Apple)
- Non stackable (Golden key)

And they are all descendants of the base class [Item](https://github.com/1Novac1/Unity_Simple-Inventory-System/blob/main/Scripts/Item/Item.cs)

#### Using these two examples, you can easily create your own items as well as expand their functionality.
> Hint: Here are the [examples](https://github.com/1Novac1/Unity_Simple-Inventory-System/blob/main/Scripts/Item/ItemsColection.cs)

You can use a static function `SpawnItem` from [`ItemWorld`](https://github.com/1Novac1/Unity_Simple-Inventory-System/blob/2955daedd6034b657c859511d639436677f74c15/Scripts/Item/ItemWorld.cs) to place an object onto the game level.
```cs
ItemWorld.SpawnItem(new Vector3(-1,1), new ItemsCollection.Apple());
 ```
# That's all =)
### You can understand more by downloading and importing my [`package`](https://github.com/1Novac1/Unity_Simple-Inventory-System/tree/2955daedd6034b657c859511d639436677f74c15/Package%20for%20unity) in Unity
### `If this information is useful to you, add feedback.`
