

Vue.component("profile-info", {
    props: ["picpath", "name", "username", "email", "address", "phonenumber", "dateofbirth"],
    data: function () {
        return {
            picturePath: this.picpath,
            Name: this.name,
            UserName: this.username,
            Email: this.email,
            Address: this.address,
            PhoneNumber: this.phonenumber,
            DateofBirth: this.dateofbirth
        }
    },
})

new Vue({
    el: "#app",
    data: {
        num1: 0,
        num2: 0,
        picked: "Summation",
    },

    computed: {
        calculate: function () {
            if (this.picked == "Summation") {
                return parseFloat(this.num1) + parseFloat(this.num2);
            } else if (this.picked == "Substraction") {
                return parseFloat(this.num1) - parseFloat(this.num2);
            } else if (this.picked == "Multiplication") {
                return parseFloat(this.num1) * parseFloat(this.num2);
            } else if (this.picked == "Division") {
                return parseFloat(this.num1) / parseFloat(this.num2);
            } else {
                return NaN;
            }
        },
    }
})

