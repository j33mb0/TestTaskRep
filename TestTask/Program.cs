using Microsoft.AspNetCore.SignalR;
using TestTask.Controllers.Messages;
using TestTask.Controllers.Users;
using TestTask.Models;
using TestTask.SignalR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSignalR();

builder.Services.AddSingleton<IMessageController, MessageController>();
builder.Services.AddSingleton<IUserController, UserController>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapHub<ChatHub>("/chat");
app.MapPost("/SendMessage", async (MessageResponse mes) =>
{
    var messageController = app.Services.GetService<IMessageController>();
    var userController = app.Services.GetService<IUserController>();

    bool userExist = await userController.UserExistence(mes.UserName);
    if (userExist == false)
        await userController.CreateNewUser(mes.UserName);
    var user = await userController.GetUserByNickname(mes.UserName);

    var newMessage = await messageController.CreateNewMessage(mes.UserName, mes.Text);
    await messageController.AddToMessagesList(newMessage);
    await userController.AddMessagesToUserMessagesList(user, newMessage);

    Console.WriteLine(newMessage.Id.ToString() + "|" + newMessage.UserName + "|" + newMessage.Text + "|" + newMessage.Time);
    return newMessage;
});

app.MapGet("/GetMessagesForContentLoadig", async () =>
{
    var messageController = app.Services.GetService<IMessageController>();
    return await messageController?.GetMessagesAsync();
});

app.MapGet("/GetUserMessages/{nickname}", async (string nickname) =>
{
    var userController = app.Services.GetService<IUserController>();
    Console.WriteLine(nickname);
    bool userExist = await userController.UserExistence(nickname);
    if (userExist == false)
        Results.NoContent();
    var user = await userController.GetUserByNickname(nickname);
    var messages = user.Messages.ToList();
    return messages;

});

app.Run();



