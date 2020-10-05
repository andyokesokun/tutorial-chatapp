let connection = new signalR.HubConnectionBuilder().withUrl("/chats").build();



// connect  to hub
connection.start().then(() => console.log("Connected"))
    .catch((err) => console.log(err));


// subscribe to an event method
connection.on("ReceivedMessage", (data) => {
    console.log(data);
    var messageEle = document.querySelector("#messages");
    var liEle = document.createElement("li");

    liEle.innerHTML = `<b>username: ${data.user} </b> ${data.message} `;

    messageEle.appendChild(liEle);

    //use data;
});


//trigger server method

function send() {
    let username = document.querySelector("[name=username]").value;
    let message = document.querySelector("[name =msg]").value;

    if (username != ""  && message !="") {

        connection.invoke("SendMessage",username, message).catch((err) => console.log(err) );

    }



}