
/*
let x = function () {
    console.log("i am called from inside the function");
};

let y = function (callback) {
    console.log("do something");
    callback();
}

y(x);
*/

/*
// doing something without call back function
let calc = function (num1, num2, calcType) {

    if (calcType.toLowerCase() === "add") {
        return num1 + num2;
    } else if (calcType.toLowerCase() === "multiply"){
        return num1 * num2;
    }
};


console.log(calc(2, 3, "Add"));
*/

//"better way to accomplish this is:

let add = function(a, b) {
    return a + b;
};

let multiply = function (a, b) {
    return a * b;
};

let doWhatever = function (a, b) {
    console.log("here are your two numbers back: ${a}, ${b}");
};

let calc = function (num1, num2, callback) {
    return callback(num1, num2);
};

console.log(calc(2, 3, add));
console.log(calc(2, 3, multiply));
console.log(calc(2, 3, doWhatever));
