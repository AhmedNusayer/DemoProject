Vue.component("jobpost-card", {
    props: ["jobpost"],
    data: function () {
        return {
            JobPost: JSON.parse(this.jobpost)
        }
    },
})