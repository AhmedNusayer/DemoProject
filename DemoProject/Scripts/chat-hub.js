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
            Messages: JSON.parse(this.msg),
            msgsender: "",
            receivedmsg: ""
        }
    },
    methods: {
        sendMessage() {
            if (this.Messages != "") {

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
                        self.Messages.push({
                            GUID: Date.now().toString(),
                            MessageDetails: self.Message,
                            Time: Date.now(),
                            UserFrom: {
                                Id: self.UserId
                            },
                            UserTo: {
                                Id: self.ToUserId
                            }
                        })
                        self.Message = ""
                        setTimeout(self.scrolldown, 500);
                    },
                })
            }
        },
        scrolldown() {
            var element = document.getElementById("chat-content");
            element.scrollTop = element.scrollHeight;
        },
        viewcv() {
            window.location.href = '/' + this.ToUserName
        }
    },
    watch: {
        receivedmsg: function (newValue) {
            if (this.msgsender == this.ToUserId) {
                this.Messages.push({
                    GUID: Date.now().toString(),
                    MessageDetails: newValue,
                    Time: Date.now(),
                    UserFrom: {
                        Id: this.msgsender
                    },
                    UserTo: {
                        Id: this.UserId
                    }
                })
            }
            setTimeout(this.scrolldown, 500);
            this.receivedmsg = newValue
        }
    },

})
