
var peopleFactory = function (name, age, state) {

    var temp = {}; // create empty object

    temp.age = age;
    temp.name = name;
    temp.state = state;

    temp.printPerson = function () {
        console.log(this.name + ", " + this.age + ", " + this.state);
    };

    return temp;
};



var person1 = peopleFactory("Derrick", 35, "CA");
var person2 = peopleFactory("Kimi", 29, "CA");

person1.printPerson();
person2.printPerson();