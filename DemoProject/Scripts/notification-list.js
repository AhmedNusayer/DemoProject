Vue.component("notification-list", {
    props: ["notifications"],
    data: function () {
        return {
            Notifications: JSON.parse(this.notifications)
        }
    },

    methods: {
        viewinfo(id) {
            window.location.href = '/Profile/ApplicantInfo?userid=' + id
        }
    }
})