import "./register-company.js"
import "./profile-info.js"

new Vue({
    el: "#app",
    data: {
        isTrue: true,
        num1: 0,
        num2: 0,
        picked: "Summation",
    },

    methods: {
        change: function () {
            this.isTrue = !this.isTrue
        }
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


