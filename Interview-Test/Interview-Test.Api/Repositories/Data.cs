using Interview_Test.Models;

namespace Interview_Test.Repositories;

public static class Data
{
    public static List<UserModel> Users =>
    [
        new UserModel
        {
            Id = Guid.Parse("F90810B6-E017-431A-9DAE-A4BA7F9BC865"),
            UserId = "user02",
            Username = "Bob.M.Jackson",
            UserProfile = new UserProfileModel
            {
                FirstName = "Bob",
                LastName = "Jackson",
                Age = 28
            },
            UserRoleMappings = new List<UserRoleMappingModel>
            {
                new()
                {
                    User = new UserModel
                    {
                        Id = Guid.Parse("F90810B6-E017-431A-9DAE-A4BA7F9BC865"),
                        UserId = "user02",
                        Username = "Bob.M.Jackson",
                        UserProfile = new UserProfileModel
                        {
                            FirstName = "Bob",
                            LastName = "Jackson",
                            Age = 28
                        }
                    },
                    Role = new()
                    {
                        RoleId = 3,
                        RoleName = "document operation",
                        Permissions = new List<PermissionModel>
                        {
                            new()
                            {
                                PermissionName = "3-01-printing-label"
                            },
                            new()
                            {
                                PermissionName = "2-04-packing-report"
                            },
                            new()
                            {
                                PermissionName = "1-04-picking-report"
                            }
                        }
                    }
                }
            }
        },
        new UserModel
        {
            Id = Guid.Parse("02CE43A4-A378-4B30-B52E-227EFA6B696E"),
            UserId = "user01",
            Username = "John.D.Smith",
            UserProfile = new UserProfileModel
            {
                FirstName = "John",
                LastName = "Smith",
                Age = null
            },
            UserRoleMappings = new List<UserRoleMappingModel>
            {
                new()
                {
                    User = new UserModel
                    {
                        Id = Guid.Parse("02CE43A4-A378-4B30-B52E-227EFA6B696E"),
                        UserId = "user01",
                        Username = "John.D.Smith",
                        UserProfile = new UserProfileModel
                        {
                            FirstName = "John",
                            LastName = "Smith",
                            Age = null
                        }
                    },
                    Role = new()
                    {
                        RoleId = 1,
                        RoleName = "pick operation",
                        Permissions = new List<PermissionModel>
                        {
                            new()
                            {
                                PermissionName = "3-01-printing-label"
                            },
                            new()
                            {
                                PermissionName = "1-04-picking-report"
                            },
                            new()
                            {
                                PermissionName = "1-01-picking-info"
                            },
                            new()
                            {
                                PermissionName = "1-03-picking-confirm"
                            },
                            new()
                            {
                                PermissionName = "1-02-picking-start"
                            }
                        }
                    }
                },
                new()
                {
                    User = new UserModel
                    {
                        Id = Guid.Parse("02CE43A4-A378-4B30-B52E-227EFA6B696E"),
                        UserId = "user01",
                        Username = "John.D.Smith",
                        UserProfile = new UserProfileModel
                        {
                            FirstName = "John",
                            LastName = "Smith",
                            Age = null
                        }
                    },
                    Role = new()
                    {
                        RoleId = 2,
                        RoleName = "pack operation",
                        Permissions = new List<PermissionModel>
                        {
                            new()
                            {
                                PermissionName = "2-03-packing-confirm"
                            },
                            new()
                            {
                                PermissionName = "2-04-packing-report"
                            },
                            new()
                            {
                                PermissionName = "1-04-picking-report"
                            },
                            new()
                            {
                                PermissionName = "2-02-packing-start"
                            },
                            new()
                            {
                                PermissionName = "3-01-printing-label"
                            },
                            new()
                            {
                                PermissionName = "2-01-packing-info"
                            }
                        }
                    }
                },
                new()
                {
                    User = new UserModel
                    {
                        Id = Guid.Parse("02CE43A4-A378-4B30-B52E-227EFA6B696E"),
                        UserId = "user01",
                        Username = "John.D.Smith",
                        UserProfile = new UserProfileModel
                        {
                            FirstName = "John",
                            LastName = "Smith",
                            Age = null
                        }
                    },
                    Role = new()
                    {
                        RoleId = 3,
                        RoleName = "document operation",
                        Permissions =new List<PermissionModel>
                        {
                            new()
                            {
                                PermissionName = "3-01-printing-label"
                            },
                            new()
                            {
                                PermissionName = "2-04-packing-report"
                            },
                            new()
                            {
                                PermissionName = "1-04-picking-report"
                            }
                        }
                    }
                }
            }
        }
    ];
}