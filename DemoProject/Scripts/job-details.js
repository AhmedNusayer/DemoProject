Vue.component("job-details", {
    props: ["postid", "postdetails"],
    data: function () {
        return {
            PostId: this.postid,
            PostDetails: JSON.parse(this.postdetails)
        }
    },

    methods: {
        Apply() {
            window.location.href = '/Home/Apply?postid=' + this.PostId
        }
    }
})