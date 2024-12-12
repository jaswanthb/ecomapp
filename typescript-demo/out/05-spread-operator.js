let arr = [1, 2, 3];
let arr1 = [1, 2, 3, "jas", "wanth"];
let arr2 = [1, 3, 5, 7];
let arr3 = [2, 4, 6, ...arr2];
function add(a, b) {
    let result = a + b;
    console.log(`Result 1 = ${result}`);
}
add(10, 20);
function addMultiple(a, b, ...nums) {
    let result = a + b;
    for (let n of nums) {
        result = result + n;
    }
    console.log(`Result 2 = ${result}`);
}
addMultiple(10, 20, 34, 45, 56, 49);
