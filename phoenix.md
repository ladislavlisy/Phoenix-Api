home—READ
employments—READ list, READ item, WRITE new item
employee—READ item, WRITE item
position—READ item, WRITE item

home -> listEmployments:
listEmployments --> home:
listEmployments -> createEmploymentForm:
createEmploymentForm --> listEmployments:
listEmployments -> readEmployment:
readEmployment --> listEmployments:
readEmployment -> addEmployeeInfoForm:
addEmployeeInfoForm --> readEmployment:
readEmployment -> addPositionInfoForm:
addPositionInfoForm --> readEmployment:


• home—READ
• onboardings—READ list, READ item, WRITE new item
• company—READ item, WRITE item
• account—READ item, WRITE item
• activity—READ item, WRITE item
• status—READ item, WRITE item (approve, rejected)

home -> listOnboardings:
listOnboardings --> home:
listOnboardings -> createOnboardingF:
createOnboardingF --> listOnboardings:
listOnboardings -> readOnboarding:
readOnboarding --> listOnboardings:
readOnboarding -> addCompanyInfoF:
addCompanyInfoF --> readOnboarding:
readOnboarding -> addAccountInfoF:
addAccountInfoF --> readOnboarding:
readOnboarding -> addActivityInfoF:
addActivityInfoF --> readOnboarding:
readOnboarding -> approveOnboardingF:
approveOnboardingF --> readOnboarding:
readOnboarding -> rejectOnboardingF:
rejectOnboardingF --> readOnboarding:

openapi: 3.0.0
info:
  description: |
    This is a sample Petstore server.  You can find
    out more about Swagger at
    [http://swagger.io](http://swagger.io) or on
    [irc.freenode.net, #swagger](http://swagger.io/irc/).
  version: "1.0.0"
  title: Swagger Petstore
  termsOfService: 'http://swagger.io/terms/'
  contact:
    email: apiteam@swagger.io
  license:
    name: Apache 2.0
    url: 'http://www.apache.org/licenses/LICENSE-2.0.html'
servers:
# Added by API Auto Mocking Plugin
  - description: SwaggerHub API Auto Mocking
    url: https://virtserver.swaggerhub.com/MzdyHrave/Petstore_sample_30/1.0.0
  - url: 'https://petstore.swagger.io/v2'
tags:
  - name: pet
    description: Everything about your Pets
    externalDocs:
      description: Find out more
      url: 'http://swagger.io'
  - name: store
    description: Access to Petstore orders
  - name: user
    description: Operations about user
    externalDocs:
      description: Find out more about our store
      url: 'http://swagger.io'
paths:
  /pet:
    post:
      tags:
        - pet
      summary: Add a new pet to the store
      operationId: addPet
      responses:
        '405':
          description: Invalid input
      security:
        - petstore_auth:
            - 'write:pets'
            - 'read:pets'
      requestBody:
        $ref: '#/components/requestBodies/Pet'
    put:
      tags:
        - pet
      summary: Update an existing pet
      operationId: updatePet
      responses:
        '400':
          description: Invalid ID supplied
        '404':
          description: Pet not found
        '405':
          description: Validation exception
      security:
        - petstore_auth:
            - 'write:pets'
            - 'read:pets'
      requestBody:
        $ref: '#/components/requestBodies/Pet'
  /pet/findByStatus:
    get:
      tags:
        - pet
      summary: Finds Pets by status
      description: Multiple status values can be provided with comma separated strings
      operationId: findPetsByStatus
      parameters:
        - name: status
          in: query
          description: Status values that need to be considered for filter
          required: true
          explode: true
          schema:
            type: array
            items:
              type: string
              enum:
                - available
                - pending
                - sold
              default: available
      responses:
        '200':
          description: successful operation
          content:
            application/json:
              schema:
                type: array
                items:
                  $ref: '#/components/schemas/Pet'
            application/xml:
              schema:
                type: array
                items:
                  $ref: '#/components/schemas/Pet'
        '400':
          description: Invalid status value
      security:
        - petstore_auth:
            - 'write:pets'
            - 'read:pets'
  /pet/findByTags:
    get:
      tags:
        - pet
      summary: Finds Pets by tags
      description: >-
        Muliple tags can be provided with comma separated strings. Use\ \ tag1,
        tag2, tag3 for testing.
      operationId: findPetsByTags
      parameters:
        - name: tags
          in: query
          description: Tags to filter by
          required: true
          explode: true
          schema:
            type: array
            items:
              type: string
      responses:
        '200':
          description: successful operation
          content:
            application/json:
              schema:
                type: array
                items:
                  $ref: '#/components/schemas/Pet'
            application/xml:
              schema:
                type: array
                items:
                  $ref: '#/components/schemas/Pet'
        '400':
          description: Invalid tag value
      security:
        - petstore_auth:
            - 'write:pets'
            - 'read:pets'
      deprecated: true
  '/pet/{petId}':
    get:
      tags:
        - pet
      summary: Find pet by ID
      description: Returns a single pet
      operationId: getPetById
      parameters:
        - name: petId
          in: path
          description: ID of pet to return
          required: true
          schema:
            type: integer
            format: int64
      responses:
        '200':
          description: successful operation
          content:
            application/json:
              schema:
                $ref: '#/components/schemas/Pet'
            application/xml:
              schema:
                $ref: '#/components/schemas/Pet'
        '400':
          description: Invalid ID supplied
        '404':
          description: Pet not found
      security:
        - api_key: []
    post:
      tags:
        - pet
      summary: Updates a pet in the store with form data
      operationId: updatePetWithForm
      parameters:
        - name: petId
          in: path
          description: ID of pet that needs to be updated
          required: true
          schema:
            type: integer
            format: int64
      responses:
        '405':
          description: Invalid input
      security:
        - petstore_auth:
            - 'write:pets'
            - 'read:pets'
      requestBody:
        content:
          application/x-www-form-urlencoded:
            schema:
              type: object
              properties:
                name:
                  description: Updated name of the pet
                  type: string
                status:
                  description: Updated status of the pet
                  type: string
    delete:
      tags:
        - pet
      summary: Deletes a pet
      operationId: deletePet
      parameters:
        - name: api_key
          in: header
          required: false
          schema:
            type: string
        - name: petId
          in: path
          description: Pet id to delete
          required: true
          schema:
            type: integer
            format: int64
      responses:
        '400':
          description: Invalid ID supplied
        '404':
          description: Pet not found
      security:
        - petstore_auth:
            - 'write:pets'
            - 'read:pets'
  '/pet/{petId}/uploadImage':
    post:
      tags:
        - pet
      summary: uploads an image
      operationId: uploadFile
      parameters:
        - name: petId
          in: path
          description: ID of pet to update
          required: true
          schema:
            type: integer
            format: int64
      responses:
        '200':
          description: successful operation
          content:
            application/json:
              schema:
                $ref: '#/components/schemas/ApiResponse'
      security:
        - petstore_auth:
            - 'write:pets'
            - 'read:pets'
      requestBody:
        content:
          application/octet-stream:
            schema:
              type: string
              format: binary
  /store/inventory:
    get:
      tags:
        - store
      summary: Returns pet inventories by status
      description: Returns a map of status codes to quantities
      operationId: getInventory
      responses:
        '200':
          description: successful operation
          content:
            application/json:
              schema:
                type: object
                additionalProperties:
                  type: integer
                  format: int32
      security:
        - api_key: []
  /store/order:
    post:
      tags:
        - store
      summary: Place an order for a pet
      operationId: placeOrder
      responses:
        '200':
          description: successful operation
          content:
            application/json:
              schema:
                $ref: '#/components/schemas/Order'
            application/xml:
              schema:
                $ref: '#/components/schemas/Order'
        '400':
          description: Invalid Order
      requestBody:
        content:
          application/json:
            schema:
              $ref: '#/components/schemas/Order'
        description: order placed for purchasing the pet
        required: true
  '/store/order/{orderId}':
    get:
      tags:
        - store
      summary: Find purchase order by ID
      description: >-
        For valid response try integer IDs with value >= 1 and <= 10.\ \ Other
        values will generated exceptions
      operationId: getOrderById
      parameters:
        - name: orderId
          in: path
          description: ID of pet that needs to be fetched
          required: true
          schema:
            type: integer
            format: int64
            minimum: 1
            maximum: 10
      responses:
        '200':
          description: successful operation
          content:
            application/json:
              schema:
                $ref: '#/components/schemas/Order'
            application/xml:
              schema:
                $ref: '#/components/schemas/Order'
        '400':
          description: Invalid ID supplied
        '404':
          description: Order not found
    delete:
      tags:
        - store
      summary: Delete purchase order by ID
      description: >-
        For valid response try integer IDs with positive integer value.\ \
        Negative or non-integer values will generate API errors
      operationId: deleteOrder
      parameters:
        - name: orderId
          in: path
          description: ID of the order that needs to be deleted
          required: true
          schema:
            type: integer
            format: int64
            minimum: 1
      responses:
        '400':
          description: Invalid ID supplied
        '404':
          description: Order not found
  /user:
    post:
      tags:
        - user
      summary: Create user
      description: This can only be done by the logged in user.
      operationId: createUser
      responses:
        default:
          description: successful operation
      requestBody:
        content:
          application/json:
            schema:
              $ref: '#/components/schemas/User'
        description: Created user object
        required: true
  /user/createWithArray:
    post:
      tags:
        - user
      summary: Creates list of users with given input array
      operationId: createUsersWithArrayInput
      responses:
        default:
          description: successful operation
      requestBody:
        $ref: '#/components/requestBodies/UserArray'
  /user/createWithList:
    post:
      tags:
        - user
      summary: Creates list of users with given input array
      operationId: createUsersWithListInput
      responses:
        default:
          description: successful operation
      requestBody:
        $ref: '#/components/requestBodies/UserArray'
  /user/login:
    get:
      tags:
        - user
      summary: Logs user into the system
      operationId: loginUser
      parameters:
        - name: username
          in: query
          description: The user name for login
          required: true
          schema:
            type: string
        - name: password
          in: query
          description: The password for login in clear text
          required: true
          schema:
            type: string
      responses:
        '200':
          description: successful operation
          headers:
            X-Rate-Limit:
              description: calls per hour allowed by the user
              schema:
                type: integer
                format: int32
            X-Expires-After:
              description: date in UTC when token expires
              schema:
                type: string
                format: date-time
          content:
            application/json:
              schema:
                type: string
            application/xml:
              schema:
                type: string
        '400':
          description: Invalid username/password supplied
  /user/logout:
    get:
      tags:
        - user
      summary: Logs out current logged in user session
      operationId: logoutUser
      responses:
        default:
          description: successful operation
  '/user/{username}':
    get:
      tags:
        - user
      summary: Get user by user name
      operationId: getUserByName
      parameters:
        - name: username
          in: path
          description: The name that needs to be fetched. Use user1 for testing.
          required: true
          schema:
            type: string
      responses:
        '200':
          description: successful operation
          content:
            application/json:
              schema:
                $ref: '#/components/schemas/User'
            application/xml:
              schema:
                $ref: '#/components/schemas/User'
        '400':
          description: Invalid username supplied
        '404':
          description: User not found
    put:
      tags:
        - user
      summary: Updated user
      description: This can only be done by the logged in user.
      operationId: updateUser
      parameters:
        - name: username
          in: path
          description: name that need to be updated
          required: true
          schema:
            type: string
      responses:
        '400':
          description: Invalid user supplied
        '404':
          description: User not found
      requestBody:
        content:
          application/json:
            schema:
              $ref: '#/components/schemas/User'
        description: Updated user object
        required: true
    delete:
      tags:
        - user
      summary: Delete user
      description: This can only be done by the logged in user.
      operationId: deleteUser
      parameters:
        - name: username
          in: path
          description: The name that needs to be deleted
          required: true
          schema:
            type: string
      responses:
        '400':
          description: Invalid username supplied
        '404':
          description: User not found
externalDocs:
  description: Find out more about Swagger
  url: 'http://swagger.io'
components:
  schemas:
    Order:
      type: object
      properties:
        id:
          type: integer
          format: int64
        petId:
          type: integer
          format: int64
        quantity:
          type: integer
          format: int32
        shipDate:
          type: string
          format: date-time
        status:
          type: string
          description: Order Status
          enum:
            - placed
            - approved
            - delivered
        complete:
          type: boolean
          default: false
      xml:
        name: Order
    Category:
      type: object
      properties:
        id:
          type: integer
          format: int64
        name:
          type: string
      xml:
        name: Category
    User:
      type: object
      properties:
        id:
          type: integer
          format: int64
        username:
          type: string
        firstName:
          type: string
        lastName:
          type: string
        email:
          type: string
        password:
          type: string
        phone:
          type: string
        userStatus:
          type: integer
          format: int32
          description: User Status
      xml:
        name: User
    Tag:
      type: object
      properties:
        id:
          type: integer
          format: int64
        name:
          type: string
      xml:
        name: Tag
    Pet:
      type: object
      required:
        - name
        - photoUrls
      properties:
        id:
          type: integer
          format: int64
        category:
          $ref: '#/components/schemas/Category'
        name:
          type: string
          example: doggie
        photoUrls:
          type: array
          xml:
            name: photoUrl
            wrapped: true
          items:
            type: string
        tags:
          type: array
          xml:
            name: tag
            wrapped: true
          items:
            $ref: '#/components/schemas/Tag'
        status:
          type: string
          description: pet status in the store
          enum:
            - available
            - pending
            - sold
      xml:
        name: Pet
    ApiResponse:
      type: object
      properties:
        code:
          type: integer
          format: int32
        type:
          type: string
        message:
          type: string
  requestBodies:
    Pet:
      content:
        application/json:
          schema:
            $ref: '#/components/schemas/Pet'
        application/xml:
          schema:
            $ref: '#/components/schemas/Pet'
      description: Pet object that needs to be added to the store
      required: true
    UserArray:
      content:
        application/json:
          schema:
            type: array
            items:
              $ref: '#/components/schemas/User'
      description: List of user object
      required: true
  securitySchemes:
    petstore_auth:
      type: oauth2
      flows:
        implicit:
          authorizationUrl: 'http://petstore.swagger.io/oauth/dialog'
          scopes:
            'write:pets': modify pets in your account
            'read:pets': read your pets
    api_key:
      type: apiKey
      name: api_key
      in: header

swagger: '2.0'
info:
  version: '1'
  title: 'Node MasterClass Course Homework 2'
  description: 'Pirple'
# Added by API Auto Mocking Plugin
host: virtserver.swaggerhub.com
basePath: /MzdyHrave/Pizza2/1
schemes:
 - https
paths:
  /login:
    post:
     description: User login with email and password
     parameters: 
      - in: body
        name: user's login data
        description: email and password of user
        schema:
          type: object 
          required:
            - email
            - password
          properties:
            email:
              type: string
              example: user.pizza@example.com
            password:
              type: string
              example: secret
     responses:
      200: 
        description: create a new login token
        schema:
          type: object
          properties:   
            email:
              type: string
              example: user.pizza@example.com
            id:
              type: string
              example: eg6w0monqgz2hbhu09g4
            expires:
              type: number
              example: 1541762240543
      400:
        description: Business logic error
        schema:
          type: object
          properties:   
            Error:
              type: string
              example: Could not find the specified user
      500: 
        description: Data error
        schema:
          type: object
          properties:   
            Error:
              type: string
              example: Could not create a new token
    put:
     description: User extending token for 1 hour from now
     parameters: 
      - in: body
        name: user's token data
        description: token id and extend flag
        schema:
          type: object 
          required:
            - id
            - extend
          properties:
            id:
              type: string
              example: eg6w0monqgz2hbhu09g4
            extend:
              type: boolean
              example: true
     responses:
      200: 
        description: extends expiration time of login token
        schema:
          type: object
          properties:   
            email:
              type: string
              example: user.pizza@example.com
            id:
              type: string
              example: eg6w0monqgz2hbhu09g4
            expires:
              type: number
              example: 1541762240543
      400:
        description: Business logic error
        schema:
          type: object
          properties:   
            Error:
              type: string
              example: Could not update token's expiration
      500: 
        description: Data error
        schema:
          type: object
          properties:   
            Error:
              type: string
              example: Token already expired and can't be extended
  /logout:
    delete:
     description: User deleting existing token
     parameters: 
      - in: query
        name: id
        description: token id
        type: string 
     responses:
      200: 
        description: delete a existing login token
      400:
        description: Business logic error
        schema:
          type: object
          properties:   
            Error:
              type: string
              example: Could not find the specified token
      500: 
        description: Data error
        schema:
          type: object
          properties:   
            Error:
              type: string
              example: Could not delete the specified token
  /users:
    get:
      description: Returns user data, for authenticated user
      parameters: 
       - in: query
         name: email
         description: user's email
         type: string
       - in: header
         name: token
         description: authentication token
         type: string
      responses:
        200: 
          description: Returns the existing user data
          schema:
            type: object
            properties:
              email:
                type: string
                example: user.pizza@example.com
              fullname:
                type: string
                example: JoHn Doe
              address:
                type: string
                example: Main street, New York 
        400:
          description: Business logic error
          schema:
            type: object
            properties:   
              Error:
                type: string
                example: Could not find the specified user
        403:
          description: Authorization error
          schema:
            type: object
            properties:   
              Error:
                type: string
                example: Missing required token in header, or given token is invalid
        500: 
          description: Data error
          schema:
            type: object
            properties:   
              Error:
                type: string
                example: Could not load user's data
    post:
      description: Create a new user
      parameters: 
       - in: body
         name: object with user data
         description: user's contact and registration data
         schema:
           type: object
           required:
            - email
            - password
            - fullname
            - address
           properties:
             email:
               type: string
               example: user.pizza@example.com
             password:
               type: string
               example: secret
             fullname:
               type: string
               example: JoHn Doe
             address:
               type: string
               example: Main street, New York   
      responses:
        200: 
          description: Create the new user data
        400:
          description: Business logic error
          schema:
            type: object
            properties:   
              Error:
                type: string
                example: A user with that email address already exists
        500: 
          description: Data error
          schema:
            type: object
            properties:   
              Error:
                type: string
                example: Could not create the new user
    put:
      description: Update data of existing user
      parameters: 
       - in: body
         name: object with user data
         description: user's contact and registration data
         schema:
           type: object
           required:
            - email
           properties:
             email:
               type: string
               example: user.pizza@example.com
             password:
               type: string
               example: secret
             fullname:
               type: string
               example: JoHn Doe
             address:
               type: string
               example: Main street, New York   
      responses:
        200: 
          description: Update user data
        400:
          description: Business logic error
          schema:
            type: object
            properties:   
              Error:
                type: string
                example: This specified user doesn't exist
        403:
          description: Authorization error
          schema:
            type: object
            properties:   
              Error:
                type: string
                example: Missing required token in header, or given token is invalid
        500: 
          description: Data error
          schema:
            type: object
            properties:   
              Error:
                type: string
                example: Could not update the user
    delete:
      description: Delete data of existing user
      parameters: 
       - in: query
         name: email
         description: user's email
         type: string
       - in: header
         name: token
         description: authentication token
         type: string
      responses:
        200: 
          description: Delete user data
        400:
          description: Business logic error
          schema:
            type: object
            properties:   
              Error:
                type: string
                example: This specified user doesn't exist
        403:
          description: Authorization error
          schema:
            type: object
            properties:   
              Error:
                type: string
                example: Missing required token in header, or given token is invalid
        500: 
          description: Data error
          schema:
            type: object
            properties:   
              Error:
                type: string
                example: Could not delete the user
  /offer:
    get:
      description: Gets all items on menu
      responses:
        200:
          description: Returns the all item
          schema:
            type: array
            items:
              properties:
                id:
                  type: string
                  example: 100
                name:
                  type: string
                  example: DIABOLA
                mixtureCzech:
                  type: string
                  example: smetana, mozzarella
                mixtureEnglish:
                  type: string
                  example: cream, mozzarella
                price:
                  type: number
                  example: 195
        400:
          description: Business logic error
          schema:
            type: object
            properties:   
              Error:
                type: string
                example: Could not find catalog items
        403:
          description: Authorization error
          schema:
            type: object
            properties:   
              Error:
                type: string
                example: Missing required token in header, or given token is invalid
        500: 
          description: Data error
          schema:
            type: object
            properties:   
              Error:
                type: string
                example: Could not load catalog items
  /shopping:
    get:
      description: Get itens in shopping cart
      parameters: 
       - in: header
         name: token
         description: authentication token
         type: string
      responses:
        200: 
          description: get list of items in shopping cart
        400:
          description: Business logic error
          schema:
            type: object
            properties:   
              Error:
                type: string
                example: Cannot find any articles to offer
        403:
          description: Authorization error
          schema:
            type: object
            properties:   
              Error:
                type: string
                example: Missing required token in header, or given token is invalid
        500: 
          description: Data error
          schema:
            type: object
            properties:   
              Error:
                type: string
                example: Could not load catalog items
    post:
      description: Add item to shopping cart
      parameters: 
       - in: header
         name: token
         description: authentication token
         type: string
       - in: body
         name: object with item id
         description: item id
         schema:
           type: object
           required:
            - id
           properties:
             id:
               type: string
               example: 100
      responses:
        200:
          description: add item to shopping cart and return list of item in shopping cart
          schema:
            type: object
            properties:
              totalPrice:
                type: number
                example: 345
              cartItems:
                type: array
                items:
                  properties:
                    id:
                      type: string
                      example: 100
                    name:
                      type: string
                      example: DIABOLA
                    mixtureCzech:
                      type: string
                      example: smetana, mozzarella
                    mixtureEnglish:
                      type: string
                      example: cream, mozzarella
                    price:
                      type: number
                      example: 195
        400:
          description: Business logic error
          schema:
            type: object
            properties:   
              Error:
                type: string
                example: Specified article doesn't exist in catalog
        403:
          description: Authorization error
          schema:
            type: object
            properties:   
              Error:
                type: string
                example: Missing required token in header, or given token is invalid
        500: 
          description: Data error
          schema:
            type: object
            properties:   
              Error:
                type: string
                example: Could not update the cart
    delete:
      description: Delete all items from shoping cart
      parameters: 
       - in: header
         name: token
         description: authentication token
         type: string
      responses:
        200: 
          description: delete all itms from shopping cart
        400:
          description: Business logic error
          schema:
            type: object
            properties:   
              Error:
                type: string
                example: Could not find user's cart
        403:
          description: Authorization error
          schema:
            type: object
            properties:   
              Error:
                type: string
                example: Missing required token in header, or given token is invalid
        500: 
          description: Data error
          schema:
            type: object
            properties:   
              Error:
                type: string
                example: Could not delete user's cart
  /checkout:
    post:
      description: place the order based on content of user's shopping cart
      parameters: 
       - in: header
         name: token
         description: authentication token
         type: string
      responses:
        200: 
          description: crete a new order, send an email and execute the users payment, clear shopping cart
        400:
          description: Business logic error
          schema:
            type: object
            properties:   
              Error:
                type: string
                example: Could not find user's cart
        403:
          description: Authorization error
          schema:
            type: object
            properties:   
              Error:
                type: string
                example: Missing required token in header, or given token is invalid
        500: 
          description: Data error
          schema:
            type: object
            properties:   
              Error:
                type: string
                example: Could not create the order