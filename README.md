# Daybook
How can we help teens self-manage their mental health in a cost-free, mindful, effective way that actually promotes long-term well-being? Introducing Daybook! 

Daybook is an intelligent journaling app that uses information about the user’s mood and the side effects of the user’s mental health disorder in order to (1) generate prompts for the user to journal about, and (2) recommend small goals/action items for the next day (e.g. go on a run, make your bed, get 15 mins of sun). By tailoring the prompts to how the user feels and giving them small goals to work towards, we’re helping users self-manage and improve their own mental well-being.

Our target audience will be 13-22 year old students in the U.S. with smartphone access, and we did this for three main reasons. First of all, this market is the easiest to enter and is most familiar to us. Second, the U.S. is one of the countries that has the least amount of stigmas surrounding mental health in the world. Finally, market research shows that this audience of roughly teenaged students really care about managing their mental health, since we’ve been raised in a time that emphasizes mental well-being. 

Our target users want to control their mental health, but don’t have the money (that $150 per session), the time, or the patience to get professional help from a therapist. When they turn to apps for mindfulness or mental health management, they’re not effective because they’re not personalized, so users don’t see real change in their mental state. So, we wanted Daybook to be a way for our target users to self-manage their mental health in a cost-free, mindful, effective way that actually promotes long-term well-being.

<h2>Story</h2>

<h3>INSPIRATION</h3>

20% of teens experience depression before they reach adulthood. 30% experience some form of anxiety. So what would most people ideally do in this situation? See a therapist. But therapy sessions cost $150 on average, and that cost makes it inaccessible for most teens. So, many teens turn to mental health apps - in fact, over 20% of teens have used mental health apps. However, 90% of mental health app users abandon use within 7 days due to a lack of personalization and effectiveness. 
Right now, there’s no good solution to this. So this begs the question, how can we help teens self-manage their mental health in a cost-free, mindful, effective way that actually promotes long-term well-being? Introducing Daybook!

<h3>APP AND TECH STACK SPECIFICS</h3>

<h4>How it will work:</h4>

See our demo for how it will work- https://drive.google.com/file/d/1DsIdJ83WM-jSyd8AYdtDxNs7clI5WHox/view?usp=sharing

<h4>How it was built:</h4>

Our entire app was hosted in Azure, and we made sure to use innovative services to most effectively solve our problem. 

<h4>Front-end</h4>

React Native - So that this app is accessible and compatible with any mobile device. 

<h4>Back-end</h4>

Azure SQL Database - To store user data on the public cloud and have an intelligent, scalable, relational database
ASP.NET Core Web Application - To create a REST API hosted on web services.
Swagger UI for API - To create an easy-to-use UI for our REST API.
Azure Cognitive Services Text Analytics - To accomplish the intelligent journaling functionality. Specifically, it leverages sentiment analysis to process the journal entries the user writes and decide what their task or action item should be. For example, the more negative their journal entries are, the less intense their tasks will be.
Azure Cognitive Services Personalizer - To accomplish the recommendation of tasks and prompts we used this reinforcement learning system.

<h4>Security</h4>

Azure Key Vault - To store authentication keys needed to access the above Azure services so that we don’t have to expose our secret keys and passwords in our config files, which would pose a huge security risk.

---

Ultimately, this tech stack allowed us to leverage these innovative Azure services and design components to create a powerful app that satisfied a clear need for a personalized, intelligent mental health management tool.
