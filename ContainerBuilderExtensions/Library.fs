namespace ContainerBuilderExtensions

open System
open DotNet.Testcontainers.Builders
open DotNet.Testcontainers.Configurations

[<System.Runtime.CompilerServices.Extension>]
module Methods =   
    [<System.Runtime.CompilerServices.Extension>]   
    let WithBindMountToUserHome(builder : ContainerBuilder, containerPath: string) =
        let userProfilePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)
        builder.WithBindMount($"{userProfilePath}", containerPath, AccessMode.ReadWrite)