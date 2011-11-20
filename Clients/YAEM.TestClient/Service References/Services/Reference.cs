﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.239
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace YAEM.TestClient.Services {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Services.IUserService", CallbackContract=typeof(YAEM.TestClient.Services.IUserServiceCallback), SessionMode=System.ServiceModel.SessionMode.Required)]
    public interface IUserService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/Register", ReplyAction="http://tempuri.org/IUserService/RegisterResponse")]
        YAEM.Domain.Session Register(YAEM.Domain.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/UnRegister", ReplyAction="http://tempuri.org/IUserService/UnRegisterResponse")]
        System.Guid UnRegister(YAEM.Domain.Session session);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/IsRegistered", ReplyAction="http://tempuri.org/IUserService/IsRegisteredResponse")]
        bool IsRegistered(YAEM.Domain.Session session);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/GetRegisteredUsers", ReplyAction="http://tempuri.org/IUserService/GetRegisteredUsersResponse")]
        System.Collections.Generic.List<YAEM.Domain.User> GetRegisteredUsers();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IUserServiceCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IUserService/NotifyUserRegistered")]
        void NotifyUserRegistered(YAEM.Domain.User user);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IUserService/NotifyUserUnRegistered")]
        void NotifyUserUnRegistered(YAEM.Domain.User user);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IUserServiceChannel : YAEM.TestClient.Services.IUserService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UserServiceClient : System.ServiceModel.DuplexClientBase<YAEM.TestClient.Services.IUserService>, YAEM.TestClient.Services.IUserService {
        
        public UserServiceClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public UserServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public UserServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public UserServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public UserServiceClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public YAEM.Domain.Session Register(YAEM.Domain.User user) {
            return base.Channel.Register(user);
        }
        
        public System.Guid UnRegister(YAEM.Domain.Session session) {
            return base.Channel.UnRegister(session);
        }
        
        public bool IsRegistered(YAEM.Domain.Session session) {
            return base.Channel.IsRegistered(session);
        }
        
        public System.Collections.Generic.List<YAEM.Domain.User> GetRegisteredUsers() {
            return base.Channel.GetRegisteredUsers();
        }
    }
}