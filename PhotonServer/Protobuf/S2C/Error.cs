// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: S2C/Error.proto
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Protobuf.S2C {

  /// <summary>Holder for reflection information generated from S2C/Error.proto</summary>
  public static partial class ErrorReflection {

    #region Descriptor
    /// <summary>File descriptor for S2C/Error.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static ErrorReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "Cg9TMkMvRXJyb3IucHJvdG8SDFByb3RvYnVmLlMyQyJcChFQcm90b01lc3Nh",
            "Z2VFcnJvchI2CglFcnJvckNvZGUYASABKA4yIy5Qcm90b2J1Zi5TMkMuUHJv",
            "dG9RdWVzdEVuZ2luZUVycm9yEg8KB01lc3NhZ2UYAiABKAkqOwoVUHJvdG9R",
            "dWVzdEVuZ2luZUVycm9yEhAKDEludmFsaWRJbnB1dBAAEhAKDFJ1bnRpbWVF",
            "cnJvchABYgZwcm90bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(new[] {typeof(global::Protobuf.S2C.ProtoQuestEngineError), }, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Protobuf.S2C.ProtoMessageError), global::Protobuf.S2C.ProtoMessageError.Parser, new[]{ "ErrorCode", "Message" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Enums
  public enum ProtoQuestEngineError {
    [pbr::OriginalName("InvalidInput")] InvalidInput = 0,
    [pbr::OriginalName("RuntimeError")] RuntimeError = 1,
  }

  #endregion

  #region Messages
  public sealed partial class ProtoMessageError : pb::IMessage<ProtoMessageError> {
    private static readonly pb::MessageParser<ProtoMessageError> _parser = new pb::MessageParser<ProtoMessageError>(() => new ProtoMessageError());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<ProtoMessageError> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Protobuf.S2C.ErrorReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ProtoMessageError() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ProtoMessageError(ProtoMessageError other) : this() {
      errorCode_ = other.errorCode_;
      message_ = other.message_;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ProtoMessageError Clone() {
      return new ProtoMessageError(this);
    }

    /// <summary>Field number for the "ErrorCode" field.</summary>
    public const int ErrorCodeFieldNumber = 1;
    private global::Protobuf.S2C.ProtoQuestEngineError errorCode_ = 0;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Protobuf.S2C.ProtoQuestEngineError ErrorCode {
      get { return errorCode_; }
      set {
        errorCode_ = value;
      }
    }

    /// <summary>Field number for the "Message" field.</summary>
    public const int MessageFieldNumber = 2;
    private string message_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Message {
      get { return message_; }
      set {
        message_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as ProtoMessageError);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(ProtoMessageError other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (ErrorCode != other.ErrorCode) return false;
      if (Message != other.Message) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (ErrorCode != 0) hash ^= ErrorCode.GetHashCode();
      if (Message.Length != 0) hash ^= Message.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (ErrorCode != 0) {
        output.WriteRawTag(8);
        output.WriteEnum((int) ErrorCode);
      }
      if (Message.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Message);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (ErrorCode != 0) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) ErrorCode);
      }
      if (Message.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Message);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(ProtoMessageError other) {
      if (other == null) {
        return;
      }
      if (other.ErrorCode != 0) {
        ErrorCode = other.ErrorCode;
      }
      if (other.Message.Length != 0) {
        Message = other.Message;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 8: {
            errorCode_ = (global::Protobuf.S2C.ProtoQuestEngineError) input.ReadEnum();
            break;
          }
          case 18: {
            Message = input.ReadString();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
