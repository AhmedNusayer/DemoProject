Vue.component("post-job", {
    data: function () {
        return {
            JobTitle: "",
            JobLocation: "",
            JobType: "",
            NoOfPosts: 1,
            SalaryRangeStart: 0,
            SalaryRangeEnd: 0,
            JobDescription: ""
        }
    },

    computed: {
        isDisabled() {
            if (this.JobTitle.length != 0 && this.JobLocation.length != 0 && this.NoOfPosts > 0 &&
                this.JobDescription.length != 0 && this.SalaryRangeEnd >= this.SalaryRangeStart
                && this.SalaryRangeStart >= 0 && this.SalaryRangeEnd >= 0) {
                return false;
            } else {
                return true;
            }
        },
    }
})