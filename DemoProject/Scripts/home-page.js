Vue.component("home-page", {
    props: ["role"],
    data: function () {
        return {
            rolename: this.role
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