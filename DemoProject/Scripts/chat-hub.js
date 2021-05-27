Vue.component("chat-hub", {
    props: ["userid", "username", "name", "picpath", "touserid", "tousername", "toname", "topicpath"],
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
        }
    }
})
