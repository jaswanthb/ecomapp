//Generics

type customeType = string|number; // Custom type declaration of what Store class 
//can extend: either string or number 

class Store<T extends customeType> {
    private list: T[];
    //private list: Array<T>; // Can be delcared in this 2 ways

    constructor() {
        this.list = []; // Initialize the list as array type
    }

    addItem(item: T) {
        this.list.push(item);
        console.log("Pushed Item: " + item);
    }

    removeItem() {
        console.log("Removed 1st element in the array")
        this.list.shift();// Remove first element in array
        //this.list.pop(); // Remove last element in array
    }

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
store1.removeItem();
store1.displayItem();

// error due to limitation of customtype where Store can extend
//let store2 = new Store<boolean>(); 