# AiWorkbench

Starting off as a proof of concept for server-side sandboxed Javascript evaluation. Hoping
to become a full-fledged enjoyable gaming experience.

## Website Plan:

    Tutorial section
        - Single player
        - Some tutorials may have computer AI
    Face-off vs AI
    Test bed for new AI scripts (upload script and test)
    Challenge other users
   
## Simulation Overview:
    
    Client receives instructions from server
        'create entity'
        'entity moved'
        'entity destroyed'

        Responsible for rendering each action
    
    Server
        Runs code for AI step by step
        Code for 'win condition'?
        Code for 'environment update'
        Send updates to client (changeset?)

## Technology Stack:
  
    Back-End:
        ASP5 vNext (dnx451 - beta5)
        MVC6
    
    Front-End:
        Grunt
        NPM
        Bower
        LESS
        Angular
        Bootstrap