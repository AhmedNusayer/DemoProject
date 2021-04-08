Vue.component("job-details", {
    props: ["postid", "postdetails"],
    data: function () {
        return {
            PostId: this.postid,
            PostDetails: JSON.parse(this.postdetails)
        }
    },

    methods: {
        
    }
})