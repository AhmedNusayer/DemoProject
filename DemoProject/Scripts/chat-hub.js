Vue.component("chat-hub", {
    props: ["userid", "username", "name", "picpath", "touserid", "tousername", "toname", "topicpath", "msg"],
    data: function () {
        return {
            UserId: this.userid,
            UserName: this.username,
            Name: this.name,
            picturePath: this.picpath,
            ToUserId: this.touserid,
            ToUserName: this.tousername,
            ToName: this.toname,
            TopicturePath: this.topicpath,
            dpPlaceholder: "/Images/dp_placeholder.png",
            Message: "",
            Messages: JSON.parse(this.msg)
        }
    },
    methods: {
        sendMessage() {
            var self = this
            var B = {
                FromUserID: self.UserId,
                ToUserID: self.ToUserId,
                Message: self.Message
            }

            $.ajax({
                type: "POST",
                url: "/Profile/SendMessage",
                data: {
                    model: B
                },
                success: function (result) {
                },
            })
        }
    }
})
