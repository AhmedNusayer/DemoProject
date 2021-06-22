Vue.component("resume-info", {
    props: ["user", "picpath"],
    data: function () {
        return {
            picturePath: this.picpath,
            dpPlaceholder: "/Images/dp_placeholder.png",
            User: JSON.parse(this.user)
        }
    }
})
