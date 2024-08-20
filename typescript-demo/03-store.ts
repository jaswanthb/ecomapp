//Generics

import { Person } from "./02-person";

type customeType = string | number| Person; // Custom type declaration of what Store class 
//can extend: either string or number or other datatype
// extends customeType
class Store<T extends customeType> {
    private list: T[];
    //private list: Array<T>; // Can be delcared in this 2 ways

    constructor() {
        this.list = []; // Initialize the list as array type in constructor
    }

    addItem(item: T) {
        this.list.push(item);
        console.log("Pushed Item: " + item);
    }
// [1,4,7,9]
//Push(10) [1,4,7,9,10]
//pop(); [1,4,7,9]
//shift(); [4,7,9]
    removeItem() {
        console.log("Removed 1st element in the array")
        this.list.shift();// Remove first element in array
        //this.list.pop(); // Remove last element in array
    }

/*
for - itreates array by position
foreach- itreates array by array element
0,1,2,3 // index
[1,3,5,8]
*/

    displayItem() {
        console.log("Displaying Items in list")
        for (let i of this.list) {
            console.log(i); // i is the actual value in array position "of"
        }

        for (let i in this.list) {
            console.log(i, this.list[i]); // i is index of array "in"
        }
    }
}

let store = new Store<string>();
store.addItem("j");
store.addItem("a")
store.addItem("s")

store.removeItem();
store.displayItem();

let store1 = new Store<number>();
store1.addItem(1);
store1.addItem(3);
store1.addItem(5);
store1.removeItem();
store1.displayItem();

// error due to limitation of customtype where Store can extend
//let store2 = new Store<boolean>(); 

let store2 = new Store<Person>();

store2.addItem(new Person(101,'P1','pemail@gmail.com'))
store2.addItem(new Person(102,'P3','p2email@gmail.com'))
store2.displayItem();
