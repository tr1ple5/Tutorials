

var peopleProto = function () {
    //create empty function
};

// using prototypes properties
peopleProto.prototype.age = 0;
peopleProto.prototype.name = "no name";
peopleProto.prototype.state = "no state";


peopleProto.prototype.printPerson = function () {
    console.log(this.age + ", " + this.name + ", " + this.state); // "this" to access
};

var person1 = new peopleProto();
person1.name = "Derrick";
person1.age = 30;
person1.state = "CA"

person1.printPerson();

//console.dir(peopleProto);