Vue.component("home-page", {
    props: ["role","user"],
    data: function () {
        return {
            rolename: this.role,
            User: JSON.parse(this.user)
        }
    },

    computed: {
        isuser() {
            if (this.rolename === "User" ) {
                return true;
            } else {
                return false;
            }
        },
        isemployer() {
            if (this.rolename === "Employer") {
                return true;
            } else {
                return false;
            }
        }
    }

})