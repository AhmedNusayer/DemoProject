Vue.component("register-user", {
    data: function () {
        return {
            FirstName: "",
            LastName: "",
            UserName: "",
            Email: "",
            Password: "",
            ConfirmPassword: "",
            VerificationCode: "",
            toggle: true,
            IsUnique: false,
            Error: ""
        }
    },

    methods: {
        validateEmail(email) {
            const re = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
            return re.test(String(email).toLowerCase());
        },
        sendMail() {
            location.href = 'SendMail/?actions=verifyuser&address=' + this.Email
        },
        isClicked() {
            this.toggle = !this.toggle
            this.sendMail()
        },
        isUserExists() {
            var self = this;
            $.ajax({
                type: "GET",
                url: "/Account/IsUserExists",
                data: {
                    username: self.UserName
                },
                success: function (result) {
                    self.IsUnique = !result
                    if (result) {
                        self.Error = "Username already exists. Please enter a different one"
                    }
                    else {
                        self.Error = ""
                    }
                },
            })
        }
    },

    computed: {
        isDisabled() {
            if (this.FirstName.length != 0 && this.LastName.length != 0 && this.Email.length != 0 &&
                this.Password.length != 0 && this.ConfirmPassword.length != 0 &&
                this.validateEmail(this.Email) && this.IsUnique) {
                return false;
            } else {
                return true;
            }
        },
    },

    watch: {
        UserName: function (newValue) {
            this.isUserExists()
            this.UserName = newValue
        }
    }

})