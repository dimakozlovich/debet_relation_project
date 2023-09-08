const hubConnection = new signalR.hubConnectionBuilder()
    .withUrl("/chat")
    .build();

document.getElementById("sendBtn").addEventListener("click", function()
{ 
    const currency = document.getElementById("currency").value;
    const summ = document.getElementById("summ").value; 
    hubConnection.invoke("Send", currency, summ)
    .catch(function (err)
    {
        return console.error(err.toString());
    })
});

hubConnection.on("Receive", function(currency, summ)
{
    const summElem = document.createElement("p");
    summElem.textContent = `${summ}`;

    const currencyElem = document.createElement("b");
    currencyElem.appendChild(summElem);
    currencyElem.appendChild(document.createTextNode(currency));

    const firstElem = document.getElementById("chatroom").firstChild;
    document.getElementById("chatroom").insertBefore(currencyElem,firstElem)
})

hubConnection.start()
    .then(function () {
        document.getElementById("sendBtn").disabled = false;
    })
    .catch(function (err) {
        return console.error(err.toString());
    });