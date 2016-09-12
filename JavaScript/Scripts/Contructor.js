
var peopleContructor = function (name, age, state) {

    this.name = name; // "this" created a property for the function object
    this.age = age;
    this.state = state;

    this.printPerson = function () {
        console.log(this.name + ", " + this.age + ", " + this.state);
    };
};


var person1 = new peopleContructor("Derrick", 35, "CA");
var person2 = new peopleContructor("Kimi", 29, "CA");

person1.printPerson();
person2.printPerson();