﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace WCFClient.Mobile {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="TimeList", Namespace="http://schemas.datacontract.org/2004/07/FKWCFServices")]
    [System.SerializableAttribute()]
    public partial class TimeList : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string BMCodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string BMNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string BMTypeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime SwipeTimeField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string BMCode {
            get {
                return this.BMCodeField;
            }
            set {
                if ((object.ReferenceEquals(this.BMCodeField, value) != true)) {
                    this.BMCodeField = value;
                    this.RaisePropertyChanged("BMCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string BMName {
            get {
                return this.BMNameField;
            }
            set {
                if ((object.ReferenceEquals(this.BMNameField, value) != true)) {
                    this.BMNameField = value;
                    this.RaisePropertyChanged("BMName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string BMType {
            get {
                return this.BMTypeField;
            }
            set {
                if ((object.ReferenceEquals(this.BMTypeField, value) != true)) {
                    this.BMTypeField = value;
                    this.RaisePropertyChanged("BMType");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime SwipeTime {
            get {
                return this.SwipeTimeField;
            }
            set {
                if ((this.SwipeTimeField.Equals(value) != true)) {
                    this.SwipeTimeField = value;
                    this.RaisePropertyChanged("SwipeTime");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Mobile.IFK")]
    public interface IFK {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFK/HelloWorld", ReplyAction="http://tempuri.org/IFK/HelloWorldResponse")]
        string HelloWorld();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFK/PushAppointment", ReplyAction="http://tempuri.org/IFK/PushAppointmentResponse")]
        string PushAppointment(string AppointmentId, string VisitorId, string VisitorName, string VisitorIdCard, string VisitorMobile);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFK/GetDoorRecord", ReplyAction="http://tempuri.org/IFK/GetDoorRecordResponse")]
        WCFClient.Mobile.TimeList[] GetDoorRecord();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IFKChannel : WCFClient.Mobile.IFK, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class FKClient : System.ServiceModel.ClientBase<WCFClient.Mobile.IFK>, WCFClient.Mobile.IFK {
        
        public FKClient() {
        }
        
        public FKClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public FKClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FKClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FKClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string HelloWorld() {
            return base.Channel.HelloWorld();
        }
        
        public string PushAppointment(string AppointmentId, string VisitorId, string VisitorName, string VisitorIdCard, string VisitorMobile) {
            return base.Channel.PushAppointment(AppointmentId, VisitorId, VisitorName, VisitorIdCard, VisitorMobile);
        }
        
        public WCFClient.Mobile.TimeList[] GetDoorRecord() {
            return base.Channel.GetDoorRecord();
        }
    }
}
