class Store {
    constructor() {
        this.list = [];
    }
    addItem(item) {
        this.list.push(item);
        console.log("Pushed Item: " + item);
    }
    removeItem() {
        console.log("Removed 1st element in the array");
        this.list.shift();
    }
    displayItem() {
        console.log("Displaying Items in list");
        for (let i of this.list) {
            console.log(i);
        }
        for (let i in this.list) {
            console.log(i, this.list[i]);
        }
    }
}
let store = new Store();
store.addItem("j");
store.addItem("a");
store.addItem("s");
store.removeItem();
store.displayItem();
let store1 = new Store();
store1.addItem(1);
store1.removeItem();
store1.displayItem();
