Vue.component("chat-list", {
    props: ["msg","userid"],
    data: function () {
        return {
            UserId: this.userid,
            Messages: JSON.parse(this.msg)
        }
    },
    methods: {
        viewchat(msg) {
            var id = ""
            if (msg.UserFrom.Id == this.UserId) {
                id = msg.UserTo.Id
            } else {
                id = msg.UserFrom.Id
            }

            location.href = '/Profile/Chat/?userid=' + id
        }
    }
})