Hello
The task is to Task
Create a RESTful API that generates upside-down kitten pictures


So I used I Clean architecture like that : 
![image](https://user-images.githubusercontent.com/40162905/148566450-b27defc9-7d47-458c-aa00-35e7a5c91386.png)

UpsideDownKittenGenerator : Controllers part

Core : core project

Infrastructure : with the In Memory Database

All tests, on project Tests (Controllers and Core)
![image](https://user-images.githubusercontent.com/40162905/148566183-3b10f71f-4c00-4970-9047-9a1190382036.png)

I did not core all tests like for password because I think most of them should be taken by the front end


You can easily test with the test project or with Swagger
![image](https://user-images.githubusercontent.com/40162905/148566770-1625d319-03df-423e-96eb-ac393b2c2e37.png)

So first you need to create an user or using an existing one an requesting user information (laurent.petitdemange0@gmail.com or test@realworldone.com)
![image](https://user-images.githubusercontent.com/40162905/148567001-dbbb589e-42cc-430e-814d-f4bdf294be55.png)
Here for the demo I left access to the password which allows you to easily change users because it is just for the test If your are not connected you will get a Unauthorized request
![image](https://user-images.githubusercontent.com/40162905/148567313-bd24a8e2-41d3-4287-bf7b-cc2707915f1f.png)

You can get a token with GetToken :
![image](https://user-images.githubusercontent.com/40162905/148567501-47ab3a19-9126-4110-9a58-1b73c7f0ff61.png)
Then you can copy paste the received token 
![image](https://user-images.githubusercontent.com/40162905/148567583-397d8fe7-c5eb-44be-bfc3-bee38a5ad498.png)

To Authorize 
![image](https://user-images.githubusercontent.com/40162905/148567667-083056df-d30a-4d04-b43c-e196d07be855.png)

Now you are able to try the Cat Image Api
![image](https://user-images.githubusercontent.com/40162905/148567789-3f1e3d26-3f8c-4665-96ad-7b899a146763.png)
you can disconnect yourself by "logout" if needed

So now you have different possibilities
![image](https://user-images.githubusercontent.com/40162905/148567909-04a8b126-fa6e-4561-84c3-218d001b2b49.png)

GetAnUpsideDownImageOfACat is the requested API
The others are extensions

![image](https://user-images.githubusercontent.com/40162905/148568054-d7fecb2d-3035-4fa1-8a41-c30d5e292e15.png)

![image](https://user-images.githubusercontent.com/40162905/148568242-ccde96a9-75c9-48d1-82a4-ef0629d4d76c.png)

I have written some documentation on Swagger but feel free to ask questions if you need them, I will be happy to chat with you

Laurent

