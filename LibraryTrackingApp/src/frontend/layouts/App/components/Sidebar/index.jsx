import {
  Box,
  Flex,
  VStack,
  Text,
  Avatar,
  Icon,
  Button,
  Divider,
} from "@chakra-ui/react";

import Link from "next/link";
import { Collapse } from "@chakra-ui/react";
import { CloseIcon } from "@chakra-ui/icons";
import { ChevronDownIcon, ChevronUpIcon } from "@chakra-ui/icons";
import { useRouter } from "next/router";
import { sidebarItems } from "@/constants/appSidebarItems";
import { useState } from "react";

function Sidebar({ isOpen }) {
  const router = useRouter();

  return (
    <Box
      bg="gray.700"
      w="275px"
      h="100vh"
      p="4"
      position="fixed"
      left="0"
      top="0"
      overflowY="auto"
      transition="0.3s ease-in-out"
      transform={isOpen ? "translateX(0)" : "translateX(-275px)"}
      boxShadow="md"
    >
      <Flex alignItems="center" mb="8">
        <Avatar size="sm" name="Admin" />
        <Text ml="3" fontSize="lg" fontWeight="bold" color="white">
          Application Panel
        </Text>
      </Flex>
      <VStack spacing="4" align="stretch">
        {sidebarItems.map((item, index) => (
          <Box key={index}>
            <SidebarItem
              icon={item.icon}
              text={item.title}
              href={item.href}
              target={item.target}
              isActive={router.pathname === item.href}
              subItems={item.subItems}
            />
          </Box>
        ))}
      </VStack>
    </Box>
  );
}

const SidebarItem = ({ icon, text, href, target, isActive, subItems }) => {
  const [isOpen, setIsOpen] = useState(false);
  const color = isActive ? "#1468de" : "gray.100";
  const router = useRouter();

  const handleToggle = () => {
    setIsOpen(!isOpen);
  };

  return (
    <>
      <Button
        variant="ghost"
        cursor={'pointer'}
        color={color}
        bg={'transparent'}
        _hover={{ color: "#1468de" }}
        leftIcon={icon}
        rightIcon={
          subItems?.length > 0 ? (
            isOpen ? (
              <ChevronUpIcon />
            ) : (
              <ChevronDownIcon />
            )
          ) : null
        }
        justifyContent="flex-start"
        onClick={subItems?.length > 0 ? handleToggle : null}
        as={subItems?.length > 0 ? null : Link}
        href={href}
        target={target}
      >
        {text}
      </Button>

      <Collapse in={isOpen}>
        <VStack spacing="1" align="stretch" ml="7">
          {subItems?.map((subItem, subIndex) => (
            <SidebarItem
              key={subIndex}
              icon={subItem.icon}
              text={subItem.title}
              href={subItem.href}
              target={subItem.target}
              isActive={router.pathname === subItem.href}
              subItems={subItem.subItems || []}
            />
          ))}
        </VStack>
      </Collapse>
    </>
  );
};

export default Sidebar;
