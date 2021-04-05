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


Vue.component("register-company", {
    data: function () {
        return {
            CompanyName: "",
            CompanyLocation: "",
            CompanyAddress: "",
            CompanyEmail: "",
            CompanyType: "",
            VerificationCode: "",
            toggle: true
        }
    },

    methods: {
        validateEmail(email) {
            const re = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
            return re.test(String(email).toLowerCase());
        },
        sendMail() {
            location.href = 'SendMail/?actions=verifycompany&address=' + this.CompanyEmail
        },
        isClicked() {
            this.toggle = !this.toggle
            this.sendMail()
        }
    },

    computed: {
        isDisabled() {
            if (this.CompanyName.length != 0 && this.CompanyLocation.length != 0 && this.CompanyAddress.length != 0 &&
                this.CompanyEmail.length != 0 && this.CompanyType.length != 0 &&
                this.validateEmail(this.CompanyEmail))
            {
                return false;
            } else {
                return true;
            }
        },
    }

})


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


